

using AsyncAwaitExample;

Console.WriteLine("Hello, async-await!");

Console.WriteLine("Started".DumpThreadId());

TaxService taxService = new TaxService();

// Operacje synchroniczne
// taxService.Calculate();

// Operacje asynchroniczne
var t1 = taxService.CalculateTask1();

var t2 = taxService.CalculateTask1();

var t3 = taxService.CalculateTask1();

await Task.WhenAll(t1, t2, t3);

Console.WriteLine("Press enter to continue...");
Console.ReadLine();