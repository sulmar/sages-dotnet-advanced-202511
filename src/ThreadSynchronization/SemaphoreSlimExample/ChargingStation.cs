using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaphoreSlimExample;

internal class ChargingStation
{
    private readonly SemaphoreSlim _semaphore;

    public ChargingStation(int maxConcurrentCharges)
    {
        _semaphore = new SemaphoreSlim(3, 3);
    }

    public async Task ChargeVehicleAsync(int vehicleId)
    {
        await _semaphore.WaitAsync(); // <--- pobieramy zeton lub czekamy jesli nie jest dostepny

        Console.WriteLine($"Pojazd {vehicleId} rozpoczal ladowanie...");

        // Symulacja czasu ladowania
        await Task.Delay(Random.Shared.Next(5000, 10_000));

        Console.WriteLine($"Pojazd {vehicleId} zakonczyl ladowanie.");

        _semaphore.Release();  // <--- oddajemy zeton
    }
}
