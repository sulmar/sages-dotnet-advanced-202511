using GetSetExample;
using System.Reflection;

Console.WriteLine("Hello, Reflection!");

Customer customer = new Customer { Name = "John Doe", Email = "john.doe@example.com", Age = 30 };

Console.Write("Podaj nazwe wlasciwosci: ");
string? propertyName = Console.ReadLine();

if (propertyName != null)
{
    Type type = customer.GetType();

    PropertyInfo property = type.GetProperty(propertyName);

    // Odczyt wartosci
    object value = property.GetValue(customer);

    Console.WriteLine(value);

    // Zapis wartosci
    property.SetValue(customer, "John Smith");

    Console.WriteLine(customer.Name);

}

// TODO:  Przypisz wartości do właściwości za pomocą indeksu
customer[propertyName] = "John Doe";
Console.WriteLine(customer[propertyName]);

