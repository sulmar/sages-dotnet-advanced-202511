// See https://aka.ms/new-console-template for more information
using ConcurrentBagExample;

Console.WriteLine("Hello, ConcurrentBag!");

// Zbiór aktywnych urządzeń IoT
var registry = new DeviceRegistry();
registry.RegisterAllDevices(iterations: 1000); // Możesz zwiększyć do 10_000