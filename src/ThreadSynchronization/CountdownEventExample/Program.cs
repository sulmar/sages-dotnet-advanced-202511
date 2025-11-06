
using CountdownEventExample;

Console.WriteLine("Hello, CountdownEvent!");

AlarmTest();

ParkingGate parkingGate = new ParkingGate(10);

var tasks = Enumerable.Range(1, 10)
    .Select(id => parkingGate.TryEnterAsync(id))
    .ToArray();

parkingGate.WaitUntilFull();

Console.WriteLine("Parking pusty");


await Task.WhenAll(tasks);

static void AlarmTest()
{    
    var service = new AlarmService(3);

    new Thread(() => service.RaiseAlarm("Czujnik A")).Start();
    new Thread(() => service.RaiseAlarm("Czujnik B")).Start();
    new Thread(() => service.RaiseAlarm("Czujnik C")).Start();

    // Główny wątek czeka 3 alarmy
    service.WaitForAllAlarms();

    // Wysyla zbiorczy raport
    SendReport();
}

static void SendReport()
{
    Console.WriteLine("Raport wysłany do administratora.");
}