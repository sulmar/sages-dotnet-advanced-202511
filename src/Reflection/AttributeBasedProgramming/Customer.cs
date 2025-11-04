using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AttributeBasedProgramming;

internal class Base : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;


    // Przykład atrybutu na poziomie parametru metody
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        Console.WriteLine(propertyName);
    }
}

internal class Customer : Base
{
    [Required, MinLength(3, ErrorMessage = "Imię zbyt krótkie")]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    private string pesel;
    public string Pesel
    {
        get
        {
            return pesel;
        }
        set
        {
            pesel = value;

            OnPropertyChanged();
        }
    }

    public Gender Gender { get; set; }

    public void DoWork()
    {
        throw new NotImplementedException();
    }
}


public enum Gender
{
    [Description("Mezczyzna")]
    Male,

    [Description("Kobieta")]
    Female
}


