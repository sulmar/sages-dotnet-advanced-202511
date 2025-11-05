
using ThreadsExample;

Console.WriteLine("Hello, Thread!");

Console.WriteLine("Started".DumpThreadId());

EmailMessageService service = new EmailMessageService();

var threads = Enumerable.Range(1, 100)
        .Select(i => new Thread(() => service.Send($"john{i}@domain.com")));

foreach (var thread in threads)
{
    thread.Start();

}

Console.WriteLine("Finished".DumpThreadId());
Console.WriteLine("Press Enter key to exit.".DumpThreadId());


Console.ReadLine();