namespace Delegates;

public class Printer
{
    public delegate void LogDelegate(string message); // sygnatura metody
    public LogDelegate Log { get; set; }


    public delegate decimal CalculateCostDelegate(int copies, decimal cost);
    public CalculateCostDelegate CalculateCost { get; set; }


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
    }

    

    private void DisplayLCD(decimal cost)
    {
        Console.WriteLine($"LCD: {cost}");
    }
}