using Newtonsoft.Json;

namespace potg.RiotGames.Dto.Match;

public sealed record ObjectivesDto
{
    [JsonProperty("baron")]
    public ObjectiveDto Baron { get; init; }

    [JsonProperty("champion")]
    public ObjectiveDto Champion { get; init; }

    [JsonProperty("dragon")]
    public ObjectiveDto Dragon { get; init; }

    [JsonProperty("inhibitor")]
    public ObjectiveDto Inhibitor { get; init; }

    [JsonProperty("riftHerald")]
    public ObjectiveDto RiftHerald { get; init; }

    [JsonProperty("tower")]
    public ObjectiveDto Tower { get; init; }
}