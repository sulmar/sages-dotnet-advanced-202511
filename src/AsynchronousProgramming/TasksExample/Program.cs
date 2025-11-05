
using System.Threading.Tasks;
using TasksExample;

Console.WriteLine("Hello, Task!");

Console.WriteLine("Started".DumpThreadId());

TaxCalculator calculator = new TaxCalculator();

// Operacje synchroniczne
//var tax1 = calculator.Calculate("John", 1000);
//var tax2 = calculator.Calculate("Kate", 2000);
//var total = tax1 + tax2;

// Operacje asynchroniczne
//var taxTask1 = calculator.CalculateTask("John", 1000);
//var taxTask2 = calculator.CalculateTask("Kate", 2000);
//var total = taxTask1.Result + taxTask2.Result; // czekamy na wynik i blokujemy glowny watek

var taxTask1 = calculator.CalculateTask("John", 1000);
var taxTask2 = calculator.CalculateTask("Kate", 2000);

var totalTask = Task.WhenAll(taxTask1, taxTask2);

EmailMessageService service = new EmailMessageService();

totalTask.ContinueWith(
    t => service.Send("john@domain.com", $"Total Tax: {taxTask1.Result + taxTask2.Result}"));

// .Result + taxTask2.Result; // czekamy na wynik i blokujemy glowny watek


Console.WriteLine("Press enter to continue...");
Console.ReadLine();

//Task task1 = new Task(() => service.Send("john@domain.com"));
//Task task2 = new Task(() => service.Send("john@domain.com"));
//Task task3 = new Task(() => service.Send("john@domain.com"));

// Zamiast
//Task task1 = new Task(() => service.Send("john@domain.com"));
// task1.Start();

// Mozemy uzyc krocej fabryki (wzorzec projektowy Fabryka - metoda fabrykujaca) taskow
Task task1 = Task.Factory.StartNew(() => service.Send("johnA@domain.com"), TaskCreationOptions.LongRunning);

// Jeszcze krocej (pod spodem uzywa powyzszej fabryki)
Task task2 = Task.Run(() => service.Send("johnB@domain.com"));

// Czekamy na zakonczenie pojedynczego zadania
// task1.Wait();

// Czekamy na zakonczenie wielu zadan
Task.WaitAll(task1, task2);

var tasks = Enumerable.Range(1, 100)
        .Select(i => new Task(() => service.Send($"john{i}@domain.com")))
        .ToList();

Thread.Sleep(1000);

foreach (var task in tasks)
{
    task.Start();
}

Console.WriteLine("Finished".DumpThreadId());
Console.WriteLine("Press Enter key to exit.".DumpThreadId());


Console.ReadLine();
