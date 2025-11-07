using System.Dynamic;
using System.Security.AccessControl;

namespace DynamicObjectExample;

internal class MyDynamic : DynamicObject
{
    private readonly IDictionary<string, object> _members = new Dictionary<string, object>();
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        return _members.TryGetValue(binder.Name, out result);        
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        _members[binder.Name] = value;

        return true;        
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        if (binder.Name == "Dump")
        {
            result = "zrzut";
        }
        else
            result = $"Wywolano metode {binder.Name} z argumentami: {string.Join(' ', args)}";


        return true;
    }
}


public class Api : DynamicObject
{
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = $"https://api.example.com/{binder.Name.ToLower()}";

        return true;
    }
}


public class DynamicPath : DynamicObject
{
    private readonly string _path;

    public DynamicPath(string path = "")
    {
        this._path = path;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = new DynamicPath($"{_path}/{binder.Name.ToLower()}");
        return true;
    }

    public override string ToString()
    {
        return _path;
    }
}