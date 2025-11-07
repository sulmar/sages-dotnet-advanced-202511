using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicExample;

interface ICommand
{
    void Execute();
}

class SendCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Send");
    }
}



interface IFoo
{
    string Name { get; set; }
    string Description { get; set; }
    byte Count {  get; set; }
}

public class Foo : IFoo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public byte Count { get; set; }
}