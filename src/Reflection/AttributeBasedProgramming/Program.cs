using AttributeBasedProgramming;
using System.Security.Cryptography;

Console.WriteLine("Hello, Attribute!");

Customer customer = new Customer();
customer.FirstName = "John";
customer.LastName = "Smith";
customer.Pesel = "1234"; // TODO: pomin przy eksporcie

var exporter = new ExporterToCsv();
var output = exporter.Export(customer);


Console.WriteLine(output);



