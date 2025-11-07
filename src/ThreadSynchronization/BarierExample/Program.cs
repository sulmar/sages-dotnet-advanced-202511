// See https://aka.ms/new-console-template for more information
using BarierExample;

Console.WriteLine("Hello, Barier!");


Console.WriteLine("Rozpoczecie aktualizacji...");

int count = 10;

UpdateService updateService = new UpdateService(3);


var tasks = Enumerable.Range(1, count)
    .Select(x => Task.Run(() => updateService.Machine($"machine-{x}")))
    .ToArray();


await Task.WhenAll(tasks);
    

