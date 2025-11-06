
using CountdownEventExample;

Console.WriteLine("Hello, CountdownEvent!");

ParkingGate parkingGate = new ParkingGate(10);

var tasks = Enumerable.Range(1, 10)
    .Select(id => parkingGate.TryEnterAsync(id))
    .ToArray();

parkingGate.WaitUntilFull();

Console.WriteLine("Parking pusty");


await Task.WhenAll(tasks);







