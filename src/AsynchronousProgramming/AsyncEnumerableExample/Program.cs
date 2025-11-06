// See https://aka.ms/new-console-template for more information
using AsyncEnumerableExample;

Console.WriteLine("Hello, Async Enumerable!".DumpThreadId());

Service service = new Service();

service.ProcessWeekdaysAsync2();

Console.WriteLine("Press Enter to exit.".DumpThreadId());
Console.ReadLine();
