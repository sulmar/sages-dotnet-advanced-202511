namespace ConsoleApp;

interface ICustomerRepository
{
    Customer Get(int id);
}

class FakeCustomerRepository : ICustomerRepository
{
    public Customer Get(int id)
    {
        return new Customer { Id = 1, FirstName = "John", LastName = "Smith", Age = 30, Pesel = "123" };
    }

    public void Add(Customer customer)
    {

    }
}

class DbCustomerRepository : ICustomerRepository
{
    public Customer Get(int id)
    {
        throw new NotImplementedException();
    }
}

internal class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }
    public string Pesel { get; set; }    
}

// Typ anonimowy
public class AnonymousType_5cn85375n83758347589734985734987534987
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }

}

//public class CustomerInfo
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public byte Age { get; set; }
//}

//public class CustomerInfo2
//{
//    public string FullName { get; set; }
//    public byte Age { get; set; }
//}