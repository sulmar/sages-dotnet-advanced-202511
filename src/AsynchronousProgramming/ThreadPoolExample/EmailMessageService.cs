using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolExample;

internal class EmailMessageService
{
    public void Send(string to)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Console.WriteLine($"Sending message to {to}...".DumpThreadId());
        File.AppendAllText($"log-{to}.txt", $"Sending message to {to}...".DumpThreadId());

        // TODO: Simulate delay from 1 to 3 s. 
        Thread.Sleep(Random.Shared.Next(30_000, 30_000));

        stopwatch.Stop();

        Console.WriteLine($"Sent to {to}. Elapsed time {stopwatch.Elapsed}".DumpThreadId());
        File.AppendAllText($"log-{to}.txt", $"Sent to {to}...".DumpThreadId());        
    }
}
