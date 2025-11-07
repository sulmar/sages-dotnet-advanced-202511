// See https://aka.ms/new-console-template for more information
using BogusExample;

Console.WriteLine("Hello, World!");


var faker = new CustomerFaker();

var customers = faker.Generate(100);


foreach (var customer in customers)
{
    Console.WriteLine(customer);
}
