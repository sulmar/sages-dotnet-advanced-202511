using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample;

internal static class ThreadHelper
{
    public static string DumpThreadId(this string message)
    {
        return $"Thread #{Thread.CurrentThread.ManagedThreadId} {message}";
    }
}
