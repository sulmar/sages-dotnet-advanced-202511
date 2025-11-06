using SemaphoreSlimExample;

Console.WriteLine("Hello, Semaphore Slim!");

var station = new ChargingStation(3);

var tasks = Enumerable.Range(1, 10)
    .Select(id => station.ChargeVehicleAsync(id))
    .ToArray();

await Task.WhenAll(tasks);


Console.WriteLine("Wszystkie pojazdy zostaly naladowane.");



return;

RequestLimiter requestLimiter = new RequestLimiter(3); // TODO: Limit to 3 concurrent requests

for (int i = 1; i <= 20; i++)
{
    int requestId = i;
    Thread thread = new Thread(() => requestLimiter.ProcessRequest(requestId));
    thread.Start();
}

Console.ReadLine();