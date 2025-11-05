
using ThreadPoolExample;

Console.WriteLine("Hello, Thread Pool!");


Console.WriteLine("Started".DumpThreadId());

EmailMessageService service = new EmailMessageService();

//ThreadPool.QueueUserWorkItem(_ => service.Send($"john@domain.com"));
//ThreadPool.QueueUserWorkItem(_ => service.Send($"kate@domain.com"));
//ThreadPool.QueueUserWorkItem(_ => service.Send($"bob@domain.com"));

//foreach(var i in Enumerable.Range(1, 100))
//{
//    ThreadPool.QueueUserWorkItem(_ => service.Send($"john{i}@domain.com"));
//}

var threads = Enumerable.Range(1, 100)
        .Select(i => ThreadPool.QueueUserWorkItem(_ => service.Send($"john{i}@domain.com")))
        .ToList();

// new Thread(() => service.Send($"john{i}@domain.com")


Console.WriteLine("Finished".DumpThreadId());
Console.WriteLine("Press Enter key to exit.".DumpThreadId());


Console.ReadLine();