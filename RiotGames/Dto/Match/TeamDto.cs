using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record TeamDto
{
    [JsonProperty("bans")]
    public IReadOnlyCollection<BanDto> Bans { get; init; }

    [JsonProperty("objectives")]
    public ObjectivesDto Objectives { get; init; }

    [JsonProperty("teamId")]
    public int TeamId { get; init; }

    [JsonProperty("win")]
    public bool Win { get; init; }
}