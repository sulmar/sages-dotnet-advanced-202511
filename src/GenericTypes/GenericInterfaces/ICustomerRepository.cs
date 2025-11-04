using System.Diagnostics.Contracts;

namespace GenericTypes;


public abstract class Base
{
  
}

public abstract class BaseEntity : Base
{
    public int Id { get; set; }
}

public class Customer : BaseEntity
{   
    public string Name { get; set; }

    public Customer(string name)
    {
        
    }

}

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
}

public class Address : Base
{
    public string Street { get; set; }
    public string City { get; set; }
}

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Color { get; set; }
}

// Szablon interfejsu (Interfejs generyczny)
public interface IEntityRepository<TEntity>
    where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}

public interface ICustomerRepository : IEntityRepository<Customer>
{
}

public interface IUserRepository : IEntityRepository<User>
{

}

public interface IProductRepository : IEntityRepository<Product>
{
    IEnumerable<Product> GetByColor(string color);
}