// See https://aka.ms/new-console-template for more information
using PeriodicTimerExample;

Console.WriteLine("Hello, Periodic Timer!".DumpThreadId());

var timer = new PeriodicTimer(TimeSpan.FromSeconds(2)); // Generuje tick co 2 sek.

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

try
{
    while (await timer.WaitForNextTickAsync(cancellationTokenSource.Token))
    {
        Console.WriteLine($"Hearbeat {DateTime.Now}".DumpThreadId());

        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            cancellationTokenSource.Cancel();
        };

        await DoSomethingAsync();
    }
}
catch(OperationCanceledException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Press Enter key to exit.".DumpThreadId());
Console.ReadLine();


async Task DoSomethingAsync()
{
    Console.WriteLine("Do something...".DumpThreadId());
    await Task.Delay(Random.Shared.Next(1000, 3000));
}


