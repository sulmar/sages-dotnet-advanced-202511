using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;

internal class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }
    public string Pesel { get; set; }
}

interface ICustomerRepository
{
    Customer Get(int id);
}

class DbContext
{

}

class DbSet<T> : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class MyContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
}

// Primary Constructor
class DbCustomerRepository(MyContext context) : ICustomerRepository
{
    //private MyContext context;

    //public DbCustomerRepository(MyContext context)
    //{
    //    this.context = context;
    //}

    public Customer Get(int id)
    {
        return context.Customers.Single(c => c.Id == id);
    } 
}

