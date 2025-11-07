// See https://aka.ms/new-console-template for more information
using DynamicExample;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, Dynamic!");


dynamic obj = "Hello";

Console.WriteLine(obj);

obj = 10;

Console.WriteLine(obj);

obj++;

Console.WriteLine(obj);


dynamic command = new SendCommand();

command.Execute();

string json = """"
     {
      "Name": "Example name",
      "Description": "Some description",
      "Count": 10,
      "Flag": true
    }
    """";

dynamic foo = JsonConvert.DeserializeObject<dynamic>(json);

// IFoo foo = (IFoo)item;

Console.WriteLine(foo.Name);

