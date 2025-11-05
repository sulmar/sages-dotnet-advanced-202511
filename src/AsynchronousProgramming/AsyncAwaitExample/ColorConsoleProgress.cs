using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample;

internal class ColorConsoleProgress : IProgress<int>
{
    public void Report(int value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(value.ToString());
        Console.ResetColor();
    }
}

// Windows Forms
class ProgressBar 
{
    private int v;

    public int Value { get => v;
        set 
        {
            v = value;

            Refresh();

        }
    }

    private void Refresh()
    {
        Console.WriteLine(Value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

class MyProgress : IProgress<int>
{
    private readonly ProgressBar control;

    public MyProgress(ProgressBar control)
    {
        this.control = control;
    }

    public void Report(int value)
    {
       control.Value = value;
    }
}