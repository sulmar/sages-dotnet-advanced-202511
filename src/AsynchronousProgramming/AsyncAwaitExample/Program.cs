

using AsyncAwaitExample;

Console.WriteLine("Hello, async-await!");

Console.WriteLine("Started".DumpThreadId());

TaxService taxService = new TaxService();

// Operacje synchroniczne
// taxService.Calculate();

// CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));
CancellationTokenSource tokenSource = new CancellationTokenSource();


var token = tokenSource.Token;

// Operacje asynchroniczne

try
{
    var t1 = taxService.CalculateAsync(token);

    Console.WriteLine("Press Esc to cancel");

    while (true)
    {
        var key = Console.ReadKey(intercept: true); // nie wypisuje klawisza
        if (key.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("Wykryto ESC");
            tokenSource.Cancel(); // Wyslanie sygnalu z prosba o przerwanie zadan

            break;
        }
    }

}
catch(Exception e)
{
    Console.WriteLine("Cancelled.");
}



Console.WriteLine("Press enter to continue...");
Console.ReadLine();