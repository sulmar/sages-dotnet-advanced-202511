using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksExample;

internal class TaxCalculator
{
    const decimal TaxRate = 0.2m; // 20% tax

    // Operacja asynchroniczna
    public Task<decimal> CalculateTask(string name, decimal salary)
    {
        return Task.Run(() => Calculate(name, salary));
    }


    // Operacja synchroniczna
    public decimal Calculate(string name, decimal salary)
    {
        Console.WriteLine($"Calculating for {name} {salary}...".DumpThreadId());

        Thread.Sleep(Random.Shared.Next(3_000, 10_000)); // Delay

        decimal tax = salary * TaxRate;

        Console.WriteLine($"Calculated for {name} {tax}.".DumpThreadId());

        return tax;
    }
}
