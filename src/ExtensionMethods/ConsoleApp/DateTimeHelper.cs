using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Helpers;

internal static class DateTimeHelper
{
    public static bool IsWeekend(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    public static DateTime AddWorkDays(this DateTime date, int workDays)
    {
        return date.AddDays(workDays);
    }
}

static class StringExtensions
{
    public static string RemovePolishLetters(this string text)
    {
        return text.Replace("©", "");
    }
}