using MongoDB.Bson;
using MongoDB.Driver;
using potg.Database.Entities.Match;
using potg.Database.Interfaces;

namespace potg.Database.Repositories;

public class MatchRepository : MongoRepository<MatchEntity>
{
    private IMongoContext Context { get; }

    public MatchRepository(IMongoContext context) : base(context.GetCollection<MatchEntity>("matches"))
    {
        Context = context;
        Collection.Indexes.CreateOne(
            new CreateIndexModel<MatchEntity>(Builders<MatchEntity>.IndexKeys.Descending(x => x.MatchId),
                new CreateIndexOptions {Unique = true}));
        Collection.Indexes.CreateOne(
            new CreateIndexModel<MatchEntity>(Builders<MatchEntity>.IndexKeys.Descending(x => x.GameEndTimestamp),
                new CreateIndexOptions {Unique = false}));
    }

    public async Task<MatchEntity?> GetMatch(string matchId)
    {
        if (string.IsNullOrEmpty(matchId))
            throw new ArgumentException("matchId이 올바르지 않습니다");

        var query = await FindAsync(x => x.MatchId == matchId);
        var summoner = await query.FirstOrDefaultAsync();

        return summoner;
    }

    public async Task<List<MatchEntity>?> GetMatches(string[] matchIds)
    {
        if (matchIds.Length == 0) return null;
        if (matchIds == null)
            throw new ArgumentException("matchIds이 올바르지 않습니다");

        var filter = Builders<MatchEntity>.Filter.In(x => x.MatchId, matchIds);
        var cursor = await Collection.FindAsync(filter);
        var list = await cursor.ToListAsync();
        return list;
    }

    public async Task<IEnumerable<string>> GetNotPresentCount(string[] matchIds)
    {
        var filter = Builders<MatchEntity>.Filter.In(x => x.MatchId, matchIds);
        var projection = Builders<MatchEntity>.Projection.Include(x => x.MatchId);
        var cursor = Collection.Find(filter).Project<MatchEntity>(projection);
        var ids = (await cursor.ToListAsync()).Select(x => x.MatchId);
        var notPresentIds = matchIds.Except(ids);
        return notPresentIds;
    }

    public async Task Save(MatchEntity match)
    {
        var query = await FindAsync(x => x.MatchId == match.MatchId);
        var found = await query.FirstOrDefaultAsync();

        if (found == null)
        {
            await InsertOneAsync(match with {Id = ObjectId.GenerateNewId()});
        }
    }

    public async Task Save(IEnumerable<MatchEntity> match)
    {
        var ops = match.Select(x => new InsertOneModel<MatchEntity>(x));

        try
        {
            await Collection.BulkWriteAsync(ops, new BulkWriteOptions {IsOrdered = true});
        }
        catch (MongoBulkWriteException)
        {
            //ignore
        }
    }
}