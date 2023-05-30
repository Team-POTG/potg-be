using FluentScheduler;

namespace potg.Jobs;

public class MainRegistry : Registry
{
    public MainRegistry()
    {
        NonReentrantAsDefault();

        Schedule<DataDragonJob>().ToRunOnceAt(6, 0).AndEvery(1).Days();
    }
}