
using ConsoleApp;

Console.WriteLine("Hello, Anonymous Types!");

decimal x = 10.0m; // wnioskowanie typu na podst. przypisanej wartosci

var customer1 = new Customer { Id = 1, FirstName = "John", LastName = "Smith", Age = 30, Pesel = "123" };
var customer2 = new Customer { Id = 2, FirstName = "Bob", LastName = "Smith", Age = 30, Pesel = "123" };
var customer3 = new Customer { Id = 3, FirstName = "Kate", LastName = "Smith", Age = 30, Pesel = "123" };

List<Customer> customers = new List<Customer> { customer1, customer2, customer3 };

var query = customers.Select(c => new { c.FirstName, c.LastName, c.Age });

var customerInfo = new { FirstName = "John", LastName = "Smith", Age = 30 };

Console.WriteLine(customerInfo.Age);

var customerInfo2 = new { FullName = "John Smith", Age = 30 };

ICustomerRepository customerRepository = new FakeCustomerRepository();
var c = customerRepository.Get(1);
// customerRepository.Add(new Customer());




