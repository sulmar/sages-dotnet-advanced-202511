using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample;

internal class TaxCalculator
{
    const decimal TaxRate = 0.2m; // 20% tax    

    // Operacja asynchroniczna
    public Task<decimal> CalculateSalaryTask(string name, decimal hours, decimal hourlyRate)
    {
        return Task.Run(() => CalculateSalary(name, hours, hourlyRate));
    }

    public Task<decimal> CalculateTaxTask(string name, decimal salary)
    {
        return Task.Run(() => CalculateTax(name, salary));
    }


    // Operacja synchroniczna
    public decimal CalculateSalary(string name, decimal hours, decimal hourlyRate)
    {
        Console.WriteLine($"Calculating salary for {name} {hours}...".DumpThreadId());

        Thread.Sleep(Random.Shared.Next(3_000, 10_000)); // Delay

        decimal salary = hours * hourlyRate;

        Console.WriteLine($"Calculated salary for {name} {salary}.".DumpThreadId());

        return salary;

    }

    public decimal CalculateTax(string name, decimal salary)
    {
        Console.WriteLine($"Calculating tax for {name} {salary}...".DumpThreadId());

        Thread.Sleep(Random.Shared.Next(3_000, 10_000)); // Delay

        decimal tax = salary * TaxRate;

        Console.WriteLine($"Calculated tax for {name} {tax}.".DumpThreadId());

        return tax;
    }


    public decimal CalculateDiscount(decimal tax)
    {
        return tax * 0.1m;
    }

    public Task<decimal> CalculateDiscountAsync(decimal tax)
    {
        // zla praktyka (dla krotkotrwalych operacji)
        // return Task.Run(() => CalculateDiscount(tax));

        // dobra praktyka
        // return Task.FromResult(100m);
        return Task.FromResult(CalculateDiscount(tax));
    }
}
