using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncEnumerableExample;

internal class Helper
{
    //public static Task<IEnumerable<string>> GetWeekdaysAsync()
    //{
    //    return Task.Run(() => GetWeekdays());
    //}

    // Leniwa kolekcja
    public static IEnumerable<string> GetWeekdays()
    {
        yield return GetIcon("pn");
        yield return GetIcon("wt");
        yield return GetIcon("sr");
        yield return GetIcon("cz");
        yield return GetIcon("pt");
        yield return GetIcon("sb");
        yield return GetIcon("nd");
    }

    public static async IAsyncEnumerable<string> GetWeekdaysAsync()
    {
        yield return await GetIconAsync("pn".DumpThreadId());
        yield return await GetIconAsync("wt".DumpThreadId());
        yield return await GetIconAsync("sr".DumpThreadId());
        yield return await GetIconAsync("cz".DumpThreadId());
        yield return await GetIconAsync("pt".DumpThreadId());
        yield return await GetIconAsync("sb".DumpThreadId());
        yield return await GetIconAsync("nd".DumpThreadId());
    }

    private static Task<string> GetIconAsync(string weekday)
    {
        return Task.Run(()=>GetIcon(weekday));
    }

    private static string GetIcon(string weekday)
    {    
        Thread.Sleep(Random.Shared.Next(1000, 10_000));

        return $"{weekday}.png";
    }
}
