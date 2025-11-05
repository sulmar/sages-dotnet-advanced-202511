

using AsyncAwaitExample;

Console.WriteLine("Hello, async-await!");

Console.WriteLine("Started".DumpThreadId());

TaxService taxService = new TaxService();

// Operacje synchroniczne
// taxService.Calculate();

// CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));
CancellationTokenSource tokenSource = new CancellationTokenSource();


var token = tokenSource.Token;

// IProgress<int> progress = new Progress<int>(step => Console.Write($"# {step:P2}"));
// IProgress<int> progress = new ColorConsoleProgress();

ProgressBar progressBar1 = new ProgressBar();

IProgress<int> progress = new MyProgress(progressBar1);

// Operacje asynchroniczne

try
{
    taxService.CalculateAsync(token, progress);

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
catch (Exception e)
{
    Console.WriteLine("Cancelled.");
}


Console.WriteLine("Press enter to continue...");
Console.ReadLine();