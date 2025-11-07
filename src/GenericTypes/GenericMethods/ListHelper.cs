using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods;

public abstract class Base
{

}

public abstract class BaseEntity : Base
{
    public int Id { get; set; }
}

public class Customer : BaseEntity, IName
{
    public string Name { get; set; }
}

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
}

public class Document : BaseEntity, IName
{
    public string Name { get; set; }
}

public interface IName
{
    public string Name { get; set; }
}

internal class ListHelper
{
    // Szablon metody (Metoda generyczna)
    public static void Dump<TItem>(IEnumerable<TItem> collection)        
    {
        foreach (TItem item in collection)
        {
            Console.WriteLine(item);
        }
    }

    public static string NameToUpper<T>(T item)
        where T : IName
    {
        return item.Name.ToUpper();
    }
     
}

class Factory
{
    public static T Create<T>()
            where T: class, new()
    {
        return new T();
    }
}
