using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivatorExample;

internal class Printer
{
    public void Print(string content, byte copies = 1)
    {
        for (int i = 0; i < copies; i++)
        {
            Console.WriteLine($"{content} copy #{i}");
        }
    }
}


class Scanner
{
    public void Scan(string filename)
    {
        Console.WriteLine(filename.Length);
    }
}
