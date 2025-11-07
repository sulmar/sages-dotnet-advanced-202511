using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivatorExample;

interface ICommand
{
    void Execute();
}

class PrintCommand : ICommand
{
    private readonly string content;
    private readonly byte copies;

    public PrintCommand(string content, byte copies = 1)
    {
        this.content = content;
        this.copies = copies;
    }

    public void Execute()
    {
        Print(content, copies);
    }

    private void Print(string content, byte copies = 1)
    {
        for (int i = 0; i < copies; i++)
        {
            Console.WriteLine($"{content} copy #{i}");
        }
    }
}

class ScanCommand : ICommand
{
    private readonly string filename;

    public ScanCommand(string filename)
    {
        this.filename = filename;
    }

    public void Execute()
    {
        Scan(filename);
    }

    private void Scan(string filename)
    {
        Console.WriteLine(filename.Length);
    }
}

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
