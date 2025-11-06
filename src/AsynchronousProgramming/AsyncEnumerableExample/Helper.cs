using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncEnumerableExample;

internal class Helper
{
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

    private static string GetIcon(string weekday)
    {    
        Thread.Sleep(1000);

        return $"{weekday}.png";
    }
}
