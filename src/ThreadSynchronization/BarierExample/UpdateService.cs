using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarierExample;

internal class UpdateService
{

    public void Machine1()
    {
        Console.WriteLine("Machine1: Aktualizacja Windows...");
        Thread.Sleep(10_000);
        Console.WriteLine("Machine1: Aktualizacja Windows. Zakonczono.");

        Console.WriteLine("Machine1: Instalacja VS");
        Thread.Sleep(5000);
        Console.WriteLine("Machine1: Instalacja VS. Zakonczono");

        Console.WriteLine("Machine1: Weryfikacja instalacji");
        Thread.Sleep(5000);
        Console.WriteLine("Machine1: Weryfikacja instalacji. Zakonczono.");
    }


    public void Machine2()
    {
        Console.WriteLine("Machine2: Aktualizacja Windows...");
        Thread.Sleep(1_000);
        Console.WriteLine("Machine2: Aktualizacja Windows. Zakonczono.");

        Console.WriteLine("Machine2: Instalacja VS");
        Thread.Sleep(2000);
        Console.WriteLine("Machine2: Instalacja VS. Zakonczono");

        Console.WriteLine("Machine2: Weryfikacja instalacji");
        Thread.Sleep(1000);
        Console.WriteLine("Machine2: Weryfikacja instalacji. Zakonczono.");
    }
}
