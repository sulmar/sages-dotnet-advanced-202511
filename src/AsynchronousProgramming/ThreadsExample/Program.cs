
using ThreadsExample;

Console.WriteLine("Hello, Thread!");

Console.WriteLine("Started".DumpThreadId());

EmailMessageService service = new EmailMessageService();

Thread thread1 = new Thread(() => service.Send("john@domain.com"));
Thread thread2 = new Thread(() => service.Send("bob@domain.com"));
Thread thread3 = new Thread(() => service.Send("kate@domain.com"));

thread1.IsBackground = false;
thread2.IsBackground = false;
thread3.IsBackground = false;

Thread.Sleep(1000);

thread1.Start();
thread2.Start();

Thread.Sleep(2000);

thread3.Start();

// service.Send("bob@domain.com");

// service.Send("kate@domain.com");

Console.WriteLine("Finished".DumpThreadId());
Console.WriteLine("Press Enter key to exit.".DumpThreadId());


Console.ReadLine();