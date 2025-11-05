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
    public Task<decimal> CalculateSalaryTask(string name, decimal hours, decimal hourlyRate, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => CalculateSalary(name, hours, hourlyRate, cancellationToken));
    }

    public Task<decimal> CalculateTaxTask(string name, decimal salary, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => CalculateTax(name, salary, cancellationToken));
    }


    // Operacja synchroniczna
    public decimal CalculateSalary(string name, decimal hours, decimal hourlyRate, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Calculating salary for {name} {hours}...".DumpThreadId());

        // Thread.Sleep(Random.Shared.Next(3_000, 10_000)); // Delay

        for (int i = 0; i < 10; i++)
        {
            //if (cancellationToken.IsCancellationRequested)
            //    throw new OperationCanceledException();

            cancellationToken.ThrowIfCancellationRequested();


            Console.Write(".");
            Thread.Sleep(Random.Shared.Next(300, 1000)); // Delay
        }


        decimal salary = hours * hourlyRate;

        Console.WriteLine($"Calculated salary for {name} {salary}.".DumpThreadId());

        return salary;

    }

    public decimal CalculateTax(string name, decimal salary, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

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


    // zla praktyka
    public async void DoWork1Async()
    {
        await Task.Run(() => DoWork());
    }

    // dobra praktyka
    public async Task DoWork2Async()
    {
        await Task.Run(() => DoWork());
    }

    public void DoWork()
    {
        Console.WriteLine("working...");

        throw new Exception();
    }
}
