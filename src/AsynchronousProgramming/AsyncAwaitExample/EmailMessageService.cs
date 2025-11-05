using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample;

internal class EmailMessageService
{
    public Task SendTask(string to, string content, CancellationToken cancellationToken = default)
    {
        return Task.Run(()=>Send(to, content, cancellationToken)); 
    }

    public void Send(string to, string content = "", CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Stopwatch stopwatch = Stopwatch.StartNew();

        Console.WriteLine($"Sending message {content} to {to}...".DumpThreadId());
        File.AppendAllText($"log-{to}.txt", $"Sending message to {to}...".DumpThreadId());

        // TODO: Simulate delay from 1 to 3 s. 
        Thread.Sleep(Random.Shared.Next(3_000, 10_000));

        stopwatch.Stop();

        Console.WriteLine($"Sent to {to}. Elapsed time {stopwatch.Elapsed}".DumpThreadId());
        File.AppendAllText($"log-{to}.txt", $"Sent to {to}...".DumpThreadId());        
    }
}
