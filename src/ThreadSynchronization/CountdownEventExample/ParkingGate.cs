using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownEventExample;

internal class ParkingGate
{
    private readonly CountdownEvent _countdown;

    private readonly object _lock = new object();

    public ParkingGate(int capacity)
    {
        _countdown = new CountdownEvent(capacity);
    }

    public async Task<bool> TryEnterAsync(int vehicleId)
    {
        Console.WriteLine($"CurrentCount: {_countdown.CurrentCount}");

        Console.WriteLine($"Pojazd {vehicleId} zaparkował...");



        await Task.Delay(Random.Shared.Next(3000, 6000)); // Symulacja czasu parkowania

        Console.WriteLine($"Pojazd {vehicleId} odjechał.");

        lock (_lock)
        {
            if (_countdown.CurrentCount > 0)
            {
                _countdown.Signal(); // Sygnal, ze samochod zakonczyl parkowanie            
            }
        }

        Console.WriteLine($"CurrentCount: {_countdown.CurrentCount}");

        return true;


    }

    public void WaitUntilFull()
    {
        _countdown.Wait();
    }

}
