namespace potg.Services;

public class JobQueueService
{
    private readonly Queue<Task> _jobQueue = new();
    private readonly object _lock = new();
    private bool _flush;

    public void Push(Task job)
    {
        var flush = false;

        lock (_lock)
        {
            _jobQueue.Enqueue(job);
            if (!flush)
            {
                flush = _flush = true;
            }
        }

        if (flush)
        {
            Flush();
        }
    }

    private void Flush()
    {
        while (true)
        {
            var job = Pop();
            if (job == null) return;

            job.Start();
        }
    }

    private Task? Pop()
    {
        lock (_lock)
        {
            if (_jobQueue.Count == 0)
            {
                _flush = false;
                return null;
            }

            return _jobQueue.Dequeue();
        }
    }
}