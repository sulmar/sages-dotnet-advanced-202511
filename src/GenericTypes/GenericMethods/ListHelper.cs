using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods;

internal class ListHelper
{
    public static void Dump(IEnumerable<int> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }

    public static void Dump(IEnumerable<string> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}
