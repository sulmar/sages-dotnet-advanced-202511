namespace AttributeBasedProgramming;

[AttributeUsage(AttributeTargets.Class)]
class IconAttribute : Attribute
{
    public string Filename { get; }

    public IconAttribute(string filename)
    {
        Filename = filename;
    }
}