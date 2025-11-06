using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarierExample;

internal class UpdateService
{
    private readonly Barrier barrier;

    public UpdateService(int count)
    {
        barrier = new Barrier(count);
    }

    public void Machine(string name)
    {
        Console.WriteLine($"{name}: Aktualizacja Windows...");
        Thread.Sleep(Random.Shared.Next(1000, 5000));
        Console.WriteLine($"{name}: Aktualizacja Windows. Zakonczono.");
        barrier.SignalAndWait();

        Console.WriteLine($"{name}: Instalacja VS");
        Thread.Sleep(Random.Shared.Next(1000, 5000));
        Console.WriteLine($"{name}: Instalacja VS. Zakonczono");
        barrier.SignalAndWait();

        Console.WriteLine($"{name}: Weryfikacja instalacji");
        Thread.Sleep(Random.Shared.Next(1000, 5000));
        Console.WriteLine($"{name}: Weryfikacja instalacji. Zakonczono.");
        barrier.SignalAndWait();
    }
    
}
