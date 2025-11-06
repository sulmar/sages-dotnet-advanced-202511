// See https://aka.ms/new-console-template for more information
using BarierExample;

Console.WriteLine("Hello, Barier!");


Console.WriteLine("Rozpoczecie aktualizacji...");

UpdateService updateService = new UpdateService();

new Thread(updateService.Machine1).Start();
new Thread(updateService.Machine2).Start();
