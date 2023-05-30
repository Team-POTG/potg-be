using MongoDB.Bson;
using MongoDB.Driver;
using potg.Database.Entities.Match;
using potg.Database.Interfaces;

namespace potg.Database.Repositories;

public class RawMatchRepository : MongoRepository<RawMatchEntity>
{
    private IMongoContext Context { get; }

    public RawMatchRepository(IMongoContext context) : base(context.GetCollection<RawMatchEntity>("matches-raw"))
    {
        Context = context;

        Collection.Indexes.CreateOne(
            new CreateIndexModel<RawMatchEntity>(Builders<RawMatchEntity>.IndexKeys.Descending(x => x.Metadata.MatchId),
                new CreateIndexOptions {Unique = true}));
    }

    public async Task<RawMatchEntity?> GetMatch(string matchId)
    {
        if (string.IsNullOrEmpty(matchId))
            throw new ArgumentException("matchId이 올바르지 않습니다");

        var query = await FindAsync(x => x.Metadata.MatchId == matchId);
        var summoner = await query.FirstOrDefaultAsync();

        return summoner;
    }

    public async Task<List<RawMatchEntity>?> GetMatches(string[] matchIds)
    {
        if (matchIds.Length == 0) return null;
        if (matchIds == null)
            throw new ArgumentException("matchIds이 올바르지 않습니다");

        var filter = Builders<RawMatchEntity>.Filter.In(x => x.Metadata.MatchId, matchIds);
        var cursor = await Collection.FindAsync(filter);
        var list = await cursor.ToListAsync();
        return list;
    }

    public async Task<IEnumerable<string>> GetNotPresentCount(string[] matchIds)
    {
        var filter = Builders<RawMatchEntity>.Filter.In(x => x.Metadata.MatchId, matchIds);
        var projection = Builders<RawMatchEntity>.Projection.Include(x => x.Metadata.MatchId);
        var cursor = Collection.Find(filter).Project<RawMatchEntity>(projection);
        var ids = (await cursor.ToListAsync()).Select(x => x.Metadata.MatchId);
        var notPresentIds = matchIds.Except(ids);
        return notPresentIds;
    }

    public async Task Save(RawMatchEntity match)
    {
        var query = await FindAsync(x => x.Metadata.MatchId == match.Metadata.MatchId);
        var found = await query.FirstOrDefaultAsync();

        if (found == null)
        {
            await InsertOneAsync(match with {Id = ObjectId.GenerateNewId()});
        }
    }

    public async Task Save(IEnumerable<RawMatchEntity> match)
    {
        var ops = match.Select(x => new InsertOneModel<RawMatchEntity>(x));

        try
        {
            await Collection.BulkWriteAsync(ops, new BulkWriteOptions {IsOrdered = false});
        }
        catch (MongoBulkWriteException)
        {
            //ignore
        }
    }
}