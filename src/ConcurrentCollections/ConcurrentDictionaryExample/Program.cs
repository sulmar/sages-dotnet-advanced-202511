// See https://aka.ms/new-console-template for more information
using ConcurrentDictionaryExample;

Console.WriteLine("Hello, ConcurrentDictionary!");


// Mapa urządzeń po IMEI

// Szybki dostęp do urządzenia po jego identyfikatorze (np. IMEI). Przydatne do aktualizacji stanu lub lokalizacji konkretnego urządzenia.

var tracker = new DeviceTracker();
tracker.SimulateParallelUpdates(1000);

if (tracker.TryGetDeviceStatus("351111111111111", out var status))
{
    Console.WriteLine($"Znaleziono: {status}");
}