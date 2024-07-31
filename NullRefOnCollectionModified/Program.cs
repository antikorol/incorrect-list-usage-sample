using System.Text.Json;

var simplifiedKubeLogic = new SimplifiedKubeLogic();

await Parallel.ForEachAsync(
    Enumerable.Range(0, 100).AsParallel(),
    async (i, token) =>
    {
        try
        {
            var services = await simplifiedKubeLogic.GetAsync();

            //var capturedServices = new List<SampleService>(services);

            //var count = capturedServices.Count;
            var count = services.Count;
            if (count > 5)
            {
                Console.WriteLine($"Must be impossible! Count: {count}");
            }

            foreach (var service in services)
            {
                if (service is null)
                {
                    Console.WriteLine("Service is null");
                    //Console.WriteLine($"Origin: {JsonSerializer.Serialize(services)}");
                    //Console.WriteLine($"Captured: {JsonSerializer.Serialize(capturedServices)}");
                    //cts.Cancel();
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    });


Console.WriteLine("Finished");