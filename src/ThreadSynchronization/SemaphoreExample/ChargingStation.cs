using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaphoreExample;

internal class ChargingStation
{
    public ChargingStation(int maxConcurrentCharges)
    {
        
    }

    public void ChargeVehicle(int vehicleId)
    {
        Console.WriteLine($"Pojazd {vehicleId} rozpoczal ladowanie...");

        // Symulacja czasu ladowania
        Thread.Sleep(Random.Shared.Next(2000, 4000));

        Console.WriteLine($"Pojazd {vehicleId} zakonczyl ladowanie.");
    }
}
