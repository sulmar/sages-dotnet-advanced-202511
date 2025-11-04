namespace Delegates;


public class PrintedEventArgs : EventArgs
{
    public int Copies { get; set; }

    public PrintedEventArgs(int copies)
    {
        Copies = copies;
    }
}

public class Printer
{
    public delegate void LogDelegate(string message); // sygnatura metody
    public LogDelegate Log;

    public delegate decimal CalculateCostDelegate(int copies, decimal cost);
    public CalculateCostDelegate CalculateCost;

    // public delegate void PrintedDelegate();
   // public delegate void PrintedDelegate(int copies);
    public delegate void PrintedDelegate(object sender, PrintedEventArgs args);
    public event PrintedDelegate Printed;


    public void Print(string content, byte copies = 1)
    {
     //   var delegates = Log.GetInvocationList();

        for (int copy = 0; copy < copies; copy++)
        {
            Log?.Invoke($"[{DateTime.Now}] Printing {content} copy #{copy}");           

            Console.WriteLine($"{DateTime.Now} Printing {content} copy #{copy}");
        }

        decimal? cost = CalculateCost(copies, 0.99M);

        if (cost.HasValue)
        {
            DisplayLCD(cost.Value);
        }

        // TODO: Send printed signal 
        Console.WriteLine($"Printed {copies} copies.");
        // Printed?.Invoke(copies);
        Printed?.Invoke(this, new PrintedEventArgs(copies));
    }

    

    private void DisplayLCD(decimal cost)
    {
        Console.WriteLine($"LCD: {cost}");
    }
}