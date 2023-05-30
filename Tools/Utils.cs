using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace potg.Tools;

public static class Utils
{
    private static readonly DateTime Epoch = DateTime.UnixEpoch;

    public static string GetRegionFromSubRegion(string subRegion)
    {
        switch (subRegion)
        {
            case "kr":
            case "jp1":
                return "asia";
            default:
                return "unk";
        }
    }

    public static ulong GetEpochTime(DateTime? now = null)
    {
        now ??= DateTime.Now;
        var span = now.Value.Subtract(Epoch);
        return (ulong) span.TotalMilliseconds;
    }

    public static async Task<string?> GetLatestLeagueVersion()
    {
        using var client = new HttpClient();
        var versionTexts = await client.GetStringAsync("https://ddragon.leagueoflegends.com/api/versions.json");
        var versions = JsonConvert.DeserializeObject<string[]>(versionTexts);

        return versions is { Length: > 0 } ? versions[0] : null;
    }
}