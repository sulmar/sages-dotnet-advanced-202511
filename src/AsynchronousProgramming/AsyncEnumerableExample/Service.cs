using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncEnumerableExample;

internal class Service
{
    public async Task ProcessWeekdaysAsync()
    {
        Console.WriteLine("ProcessWeekdaysAsync started".DumpThreadId());

        foreach (var weekday in Helper.GetWeekdays())
        {
            // Process
            await Task.Run(() => Console.WriteLine($"Send message with {weekday}".DumpThreadId()));
        }

        Console.WriteLine("ProcessWeekdaysAsync finished".DumpThreadId());
    }

    public async Task ProcessWeekdaysAsync2()
    {
        await foreach (var weekday in Helper.GetWeekdaysAsync())
        {
            // Process
            await Task.Run(() => Console.WriteLine($"Send message with {weekday}".DumpThreadId()));
        }

    }
}
