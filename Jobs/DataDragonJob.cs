using FluentScheduler;
using potg.RiotGames;
using potg.Tools;

namespace potg.Jobs;

public class DataDragonJob : IJob
{
    public async void Execute()
    {
        var latestVersion = await Utils.GetLatestLeagueVersion();
        if (latestVersion != null)
        {
            await DataDragon.Instance.Load(latestVersion);
        }
    }
}