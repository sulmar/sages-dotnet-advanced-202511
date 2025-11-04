using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorExample;

internal class Customer : IEnumerable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } = string.Empty;

    public IEnumerator GetEnumerator()
    {
        yield return Id;
        yield return FirstName;
        yield return LastName;
    }
}


class DateHelper
{
    // Zachlanne podejscie (Eager)
    public static IEnumerable<string> GetDaysOfWeek()
    {
        List<string> daysOfWeek = new List<string>();
        daysOfWeek.Add("pn");
        daysOfWeek.Add("wt");
        daysOfWeek.Add("sr");
        daysOfWeek.Add("cz");
        daysOfWeek.Add("pt");
        daysOfWeek.Add("sb");
        daysOfWeek.Add("nd");

        return daysOfWeek;
    }

    // Leniwe podejscie (Lazy)

    public static IEnumerable<string> GetDaysOfWeekByYield()
    {
        yield return "pn";
        yield return "wt";
        yield return "sr";
        yield return "cz";
        yield return "pt";
        yield return "sb";
        yield return "nd";
    }

    public static IEnumerable<string> GetWeekend()
    {
        while (true)
        {
            Thread.Sleep(1000);

            yield return "weekend";
        }
    }
}