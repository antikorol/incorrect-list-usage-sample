public class SimplifiedKubeLogic
{
    private readonly List<SampleService> _services;

    private volatile int _index = 0;

    public SimplifiedKubeLogic()
    {
        _services = new List<SampleService>();
    }

    public virtual async Task<List<SampleService>> GetAsync()
    {
        await Task.Yield();

        _services.Clear();

        _services.AddRange(
            new[]
            {
                new SampleService { Host = Interlocked.Increment(ref _index) },
                new SampleService { Host = Interlocked.Increment(ref _index) },
                new SampleService { Host = Interlocked.Increment(ref _index) },
                new SampleService { Host = Interlocked.Increment(ref _index) },
                new SampleService { Host = Interlocked.Increment(ref _index) },
            });

        return _services;
    }
}
