

using AsyncAwaitExample;

Console.WriteLine("Hello, async-await!");

Console.WriteLine("Started".DumpThreadId());

TaxService taxService = new TaxService();

// Operacje synchroniczne
// taxService.Calculate();

// Operacje asynchroniczne
var t1 = taxService.CalculateAsync();

var t2 = taxService.CalculateAsync();

var t3 = taxService.CalculateAsync();

await Task.WhenAll(t1, t2, t3);

Console.WriteLine("Press enter to continue...");
Console.ReadLine();