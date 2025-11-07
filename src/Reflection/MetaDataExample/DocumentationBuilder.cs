using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataExample;

// Wzorzec budowniczy
internal class DocumentationBuilder
{
    private readonly StringBuilder _builder = new StringBuilder();
    private Type _type;

    public DocumentationBuilder WithType(Type type)
    {
        _type = type;

        return this;
    }

    public DocumentationBuilder GenerateHeader()
    {
        _builder.AppendLine("---------------");
        _builder.AppendLine($"{_type.Namespace}.{_type.Name}");
        _builder.AppendLine("---------------");

        return this;
    }

    public DocumentationBuilder GenerateProperties()
    {
        PropertyInfo[] properties = _type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            _builder.AppendLine($"{property.Name} {property.PropertyType}");
        }

        return this;
    }

    public DocumentationBuilder GenerateMethods()
    {
        MethodInfo[] methods = _type.GetMethods();

        foreach (MethodInfo method in methods)
        {
            _builder.AppendLine($"{method.Name} {method.ReturnType}");
        }

        return this;
    }

    public DocumentationBuilder GenerateConstructors()
    {
        ConstructorInfo[] constructors = _type.GetConstructors();

        foreach (ConstructorInfo constructor in constructors)
        {
            _builder.AppendLine($"{constructor.Name}");


            foreach (ParameterInfo parameter in constructor.GetParameters())
            {
                _builder.AppendLine($"{parameter.Name} {parameter.ParameterType}");
            }
        }

        return this;
    }

    public DocumentationBuilder GenerateEvents()
    {        
        EventInfo[] events = _type.GetEvents();
        
        foreach (EventInfo @event in events)
        {
            _builder.AppendLine($"{@event.Name} {@event.EventHandlerType.Name}");
        }

        return this;
    }


    public DocumentationBuilder GenerateFooter()
    {
        return this;
    }

    // Zwraca product
    public string Build()
    {
        return _builder.ToString(); // Odpowiednik metody Build
    }

}
