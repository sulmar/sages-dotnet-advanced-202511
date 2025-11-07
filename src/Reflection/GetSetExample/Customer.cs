using System.Reflection;

namespace GetSetExample;

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public byte Age { get; set; }

    // Wlasny indekser [propertyName]
    /*
    public object this[string propertyName]
    {
        get
        {
            Type type = this.GetType();

            PropertyInfo property = type.GetProperty(propertyName);

            object value = property.GetValue(this);

            return value;

        }

        set
        {
            Type type = this.GetType();

            PropertyInfo property = type.GetProperty(propertyName);

            property.SetValue(this, value);

        }
    }

    */


    public object this[string propertyName]
    {
        get => GetType().GetProperty(propertyName).GetValue(this);
        set => GetType().GetProperty(propertyName).SetValue(this, value);
    }
}
