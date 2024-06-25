# Result of running this sample

```
public class SimplifiedKubeLogic // This is the simplified logic of the class  Kube where I removed everything unnecessary and kept only the modification of the list from different threads.
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

        _services.AddRange(new[] { new SampleService { Host = Interlocked.Increment(ref _index) } });

        return _services;
    }
}
```

<img width="554" alt="image" src="https://github.com/antikorol/incorrect-list-usage-sample/assets/61905975/355834f2-7c30-44eb-878a-7fd6e53cf43b">
