using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataExample;

public abstract class Base
{

}

public class Customer : Base, INotifyPropertyChanged
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }

    public Customer()
    {
        
    }

    public Customer(string name)
        : base()
    {
        this.Name = name;
    }

    public event PropertyChangedEventHandler? PropertyChanged
    {
        add
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("podpieto zdarzenie");
            Console.ResetColor();
        }

        remove
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("odpieto zdarzenie");
            Console.ResetColor();
        }
    }

    private bool isRemoved;

    public void Remove()
    {
        SoftDelete();
    }

    private void SoftDelete()
    {
        isRemoved = true;
    }

    

}
