using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaphoreExample;

internal class ChargingStation
{
    private readonly Semaphore _semaphore;

    public ChargingStation(int maxConcurrentCharges)
    {
        _semaphore = new Semaphore(3, 3);
    }

    public void ChargeVehicle(int vehicleId)
    {
        _semaphore.WaitOne(); // <--- pobieramy zeton lub czekamy jesli nie jest dostepny

        Console.WriteLine($"Pojazd {vehicleId} rozpoczal ladowanie...");

        // Symulacja czasu ladowania
        Thread.Sleep(Random.Shared.Next(5000, 10_000));

        Console.WriteLine($"Pojazd {vehicleId} zakonczyl ladowanie.");

        _semaphore.Release();  // <--- oddajemy zeton
    }
}
