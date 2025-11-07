using System.Reflection;
using System.Text;

namespace AttributeBasedProgramming;

internal class ExporterToCsv
{
    // name;pesel,age
    // John;44545;30
    // John;44545;30

    private readonly StringBuilder _builder = new StringBuilder();

    private void AddHeader<T>()
    {
        Type type = typeof(T);

        // Pobieramy wszystkie wlasciwosci
        var properties = type.GetProperties();

        // Pobieramy wlasciwosci z atrybutem [Ignore]
        var ignoreProperties = new List<PropertyInfo>();

        foreach (var property in properties)
        {
            if (Attribute.IsDefined(property, typeof(IgnoreAttribute)))
            {
                Console.WriteLine($"{property} posiada IgnoreAttribute");

                ignoreProperties.Add(property);
            }
        }

        // Pomijamy ignorowane wlasciwosci za pomoca roznicy zbiorow
        properties = properties.Except(ignoreProperties).ToArray();

        var header = string.Join(";", properties.Select(p => p.Name).ToArray());

        _builder.AppendLine(header);

    }

    public string Export<T>(T item)
    {
        AddHeader<T>();

        Type type = item.GetType();

        // Pobieramy wszystkie wlasciwosci
        var properties = type.GetProperties();

        // Pobieramy wlasciwosci z atrybutem [Ignore]
        var ignoreProperties = new List<PropertyInfo>();

        foreach (var property in properties)
        {
            if (Attribute.IsDefined(property, typeof(IgnoreAttribute)))
            {
                Console.WriteLine($"{property} posiada IgnoreAttribute");

                ignoreProperties.Add(property);
            }
        }

        // Pomijamy ignorowane wlasciwosci za pomoca roznicy zbiorow
        properties = properties.Except(ignoreProperties).ToArray();


        var row = string.Join(";", properties.Select(p => p.GetValue(item)));

        _builder.AppendLine(row);

        return _builder.ToString();
    }
}
