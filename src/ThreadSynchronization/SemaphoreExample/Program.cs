using SemaphoreExample;

Console.WriteLine("Hello, Semaphore!");

var station = new ChargingStation(3);

var tasks = Enumerable.Range(1, 10)
    .Select(id => Task.Run(() => station.ChargeVehicle(id)))
    .ToArray();

await Task.WhenAll(tasks);


Console.WriteLine("Wszystkie pojazdy zostaly naladowane.");