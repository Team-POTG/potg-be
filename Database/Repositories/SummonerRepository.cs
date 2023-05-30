using MongoDB.Bson;
using MongoDB.Driver;
using potg.Data;
using potg.Database.Entities;
using potg.Database.Interfaces;

namespace potg.Database.Repositories;

public class SummonerRepository : MongoRepository<SummonerEntity>
{
	private IMongoContext Context { get; }

	public SummonerRepository(IMongoContext context) : base(context.GetCollection<SummonerEntity>("summoners"))
	{
		Context = context;
	}

	public async Task<string?> GetPuuid(string name, string subRegion)
	{
		if (string.IsNullOrEmpty(name))
			throw new ArgumentException("name이 올바르지 않습니다");

		if (string.IsNullOrEmpty(subRegion))
			throw new ArgumentException("region이 올바르지 않습니다");

		var query = await FindAsync(x => x.Name == name && x.SubRegion == subRegion);
		var summoner = await query.FirstOrDefaultAsync();

		return summoner?.Puuid;
	}

	public async Task<SummonerEntity?> GetByName(string name, string subRegion)
	{
		if (string.IsNullOrEmpty(name))
			throw new ArgumentException("name이 올바르지 않습니다");

		if (string.IsNullOrEmpty(subRegion))
			throw new ArgumentException("region이 올바르지 않습니다");

		var query = await FindAsync(x => x.Name == name && x.SubRegion == subRegion);
		var summoner = await query.FirstOrDefaultAsync();

		return summoner;
	}

	public async Task<IEnumerable<SummonerSearchResult>> GetSummoners(string inputText, string subRegion)
	{
		if (string.IsNullOrEmpty(inputText))
			throw new ArgumentException("inputText이 올바르지 않습니다");

		if (string.IsNullOrEmpty(subRegion))
			throw new ArgumentException("region이 올바르지 않습니다");

		var query = await FindAsync(x => x.SearchName.Trim().Contains(inputText) && x.SubRegion == subRegion);
		var list = await query.ToListAsync();
		var perfectMatch = list.FirstOrDefault(x => string.Equals(x.Name, inputText, StringComparison.CurrentCultureIgnoreCase));
		var perfectMatchSolo = perfectMatch?.Ranks.FirstOrDefault(x => x.QueueType == "RANKED_SOLO_5x5");
		var result =
				list.Select(summoner => new { summoner, solo = summoner.Ranks.FirstOrDefault(x => x.QueueType == "RANKED_SOLO_5x5") })
						.Select(t => t.solo != null ? new SummonerSearchResult(t.summoner.Name, t.solo.Tier, t.solo.Rank, t.solo.LeaguePoints, t.summoner.Level, t.summoner.ProfileIconId) : new SummonerSearchResult(t.summoner.Name, -1, -1, -1, t.summoner.Level, t.summoner.ProfileIconId))
						.OrderByDescending(x => x.Tier)
						.ThenBy(x => x.Tier)
						.ThenByDescending(x => -x.Rank)
						.ThenByDescending(x => x.Lp)
						.ThenByDescending(x => x.Level)
						.Take(perfectMatch != null ? 4 : 5)
						.ToList();

		if (perfectMatch != null)
		{
			result.Remove(result.First(x => x.Name == perfectMatch.Name));
			result.Add(perfectMatchSolo != null ? new SummonerSearchResult(perfectMatch.Name, perfectMatchSolo.Tier, perfectMatchSolo.Rank, perfectMatchSolo.LeaguePoints, perfectMatch.Level, perfectMatch.ProfileIconId) : new SummonerSearchResult(perfectMatch.Name, -1, -1, -1, perfectMatch.Level, perfectMatch.ProfileIconId));
			result.Reverse();
		}

		return result;
	}

	public async Task Save(SummonerEntity summoner)
	{
		var query = await FindAsync(x => x.Puuid == summoner.Puuid && x.SubRegion == summoner.SubRegion);
		var found = await query.FirstOrDefaultAsync();

		if (found != null)
		{
			await ReplaceOneAsync(summoner with { Id = found.Id });
			return;
		}

		await InsertOneAsync(summoner with { Id = ObjectId.GenerateNewId() });
	}
}