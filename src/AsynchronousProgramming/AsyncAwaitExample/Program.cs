

using AsyncAwaitExample;

Console.WriteLine("Hello, async-await!");

Console.WriteLine("Started".DumpThreadId());

TaxCalculator calculator = new TaxCalculator();
EmailMessageService service = new EmailMessageService();

// Operacje synchroniczne
//var salary1 = calculator.CalculateSalary("John", 100, 10);
//var salary2 = calculator.CalculateSalary("Kate", 50, 40);

//var tax1 = calculator.CalculateTax("John", salary1);
//var tax2 = calculator.CalculateTax("Kate", salary2);

//var total = tax1 + tax2;

// Operacje asynchroniczne

var salary1Task = calculator.CalculateSalaryTask("John1", 100, 10);
salary1Task.ContinueWith(t => calculator.CalculateTaxTask("John2", t.Result));

var salary2Task = calculator.CalculateSalaryTask("Kate1", 50, 40);
salary2Task.ContinueWith(t => calculator.CalculateTaxTask("Kate2", t.Result));


Task.WhenAll(salary1Task, salary2Task)
        .ContinueWith(t => service.Send("john@domain.com", $"Total: {salary1Task.Result + salary2Task.Result}"));


Console.WriteLine("Press enter to continue...");
Console.ReadLine();