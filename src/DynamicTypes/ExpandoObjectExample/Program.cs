// See https://aka.ms/new-console-template for more information
using ExpandoObjectExample;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text.Json;

Console.WriteLine("Hello, Expando Object!");







// ExpandoObject dziala jak slownik IDictionary<string, object>

dynamic person = new ExpandoObject();

person.Name = "John";
person.Age = 30;
person.SayHello = (Action)(() => Console.WriteLine($"Hello {person.Name}!")); 

Console.WriteLine(person.Name);
Console.WriteLine(person.Age);

person.SayHello();

var dict = (IDictionary<string, object>) person;

dict.Remove("Age");

dict.Add("Pesel", "1111");


Console.WriteLine(person.Pesel);
// Console.WriteLine(person.Age);


string json = """"
     {
      "Name": "Example name",
      "Description": "Some description",
      "Count": 10,
      "Flag": true
    }
    """";

// dynamic foo = JsonSerializer.Deserialize<ExpandoObject>(json);
dynamic foo = JsonConvert.DeserializeObject<ExpandoObject>(json);
foo.CreateDate = DateTime.Now;

CustomerDto dto = new CustomerDto();
dto.Name = foo.Name;
dto.Address = foo.Description + foo.Count.ToString();

Console.WriteLine(dto.Name);
Console.WriteLine(dto.Address);




