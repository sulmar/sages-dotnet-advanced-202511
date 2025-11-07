using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeBasedProgramming;

internal class ExporterToCsv
{
    // name;pesel,age
    // John;44545;30
    // John;44545;30

    private StringBuilder _builder = new StringBuilder();

    private void AddHeader<T>()
    {
        Type type = typeof(T);

        var properties = type.GetProperties();

        var header = string.Join(";", properties.Select(p => p.Name).ToArray());

        _builder.AppendLine(header);

    }

    public string Export<T>(T item)
    {
        AddHeader<T>();

        Type type = item.GetType();

        var properties = type.GetProperties();

        var row = string.Join(";", properties.Select(p => p.GetValue(item)).ToArray());

        _builder.AppendLine(row);

        return _builder.ToString();
    }
}
