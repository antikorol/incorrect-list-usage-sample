var simplifiedKubeLogic = new SimplifiedKubeLogic();

using var cts = new CancellationTokenSource();

await Parallel.ForEachAsync(
    Enumerable.Range(0, 100).AsParallel(),
    cts.Token,
    async (i, token) =>
    {
        try
        {
            var services = await simplifiedKubeLogic.GetAsync();

            if (services.Count > 1)
            {
                Console.WriteLine("Must be impossible!");
            }

            foreach (var service in services)
            {
                if (service is null)
                {
                    Console.WriteLine("Service is null");
                    cts.Cancel();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    });


Console.WriteLine("Finished");