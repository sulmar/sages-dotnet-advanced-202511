// See https://aka.ms/new-console-template for more information
using AsyncEnumerableExample;

Console.WriteLine("Hello, Async Enumerable!".DumpThreadId());


foreach(var weekday in Helper.GetWeekdays())
{
    Task.Run(()=> Console.WriteLine(weekday.DumpThreadId()));
}


Console.WriteLine("Press Enter to exit.".DumpThreadId());
Console.ReadLine();
