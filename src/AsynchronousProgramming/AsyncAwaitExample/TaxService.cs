using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample;

internal class TaxService
{
    TaxCalculator calculator = new TaxCalculator();
    EmailMessageService service = new EmailMessageService();

    public void Calculate()
    {
        var salary1 = calculator.CalculateSalary("John", 100, 10);
        var salary2 = calculator.CalculateSalary("Kate", 50, 40);

        var tax1 = calculator.CalculateTax("John", salary1);
        var tax2 = calculator.CalculateTax("Kate", salary2);

        var total = tax1 + tax2;
        service.Send("john@domain.com", $"Total: {total}");
    }

    public async Task CalculateTask2()
    {
        var salary1 = calculator.CalculateSalaryTask("John1", 100, 10)
                              .ContinueWith(t => calculator.CalculateTaxTask("John2", t.Result))
                                .ContinueWith(t2 => service.SendTask("john@domain.com", $"Total: {t2.Result}"));
    }

    public void CalculateSync()
    {
        var salary = calculator.CalculateSalary("John1", 100, 10);
        var tax = calculator.CalculateTax("John2", salary);
        service.Send("john@domain.com", $"Tax: {tax}");
    }

    public async Task CalculateAsync(CancellationToken cancellationToken = default)
    {
        var salary = await calculator.CalculateSalaryTask("John1", 100, 10, cancellationToken);          
        var tax = await calculator.CalculateTaxTask("John2", salary, cancellationToken);
        await service.SendTask("john@domain.com", $"Tax: {tax}");
    }

    public async Task CalculateTaskWithSynchronize1()
    {        
        var salary = await calculator.CalculateSalaryTask("John1", 100, 10)
            .ConfigureAwait(false);  // Wylaczenie synchronizacji

        // label1.Text = salary;
       //Console.WriteLine($"Salary: {salary}".DumpThreadId());

        var tax = await calculator.CalculateTaxTask("John2", salary)
            .ConfigureAwait(false); // Wylaczenie synchronizacji

        await service.SendTask("john@domain.com", $"Tax: {tax}");
    }


    public async Task CalculateTask()
    {
        // rownolegle
        var salaryTask1 = calculator.CalculateSalaryTask("John1", 100, 10);
        var salaryTask2 = calculator.CalculateSalaryTask("Kate1", 50, 40);

        await Task.WhenAll(salaryTask1, salaryTask2);

        // rownolegle
        var taxTask1 = calculator.CalculateTaxTask("John2", salaryTask1.Result);          
        var taxTask2 = calculator.CalculateTaxTask("Kate2", salaryTask2.Result);

        await Task.WhenAll(taxTask1, taxTask1);

        var total = taxTask1.Result + taxTask2.Result;
        await service.SendTask("john@domain.com", $"Total: {total}");
    }
}
