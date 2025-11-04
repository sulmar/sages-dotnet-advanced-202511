namespace GenericClassses;

#region Models

public abstract class Base
{

}

public abstract class BaseEntity : Base
{
    public int Id { get; set; }
}

public class Customer : BaseEntity
{
    public int CustomerId { get; set; }
    public required string Name { get; set; }

    public override string ToString()
    {
        return $"CustomerId: {CustomerId} Name: {Name}";
    }
}

public class Account : BaseEntity
{
    public int AccountId { get; set; }
    public required string Number { get; set; }
    public decimal Balance { get; set; }
    public override string ToString()
    {
        return $"AccountId: {AccountId} Number: {Number} Balance: {Balance}";
    }
}

#endregion

public class InMemoryCustomerRepository
{
    private readonly IDictionary<int, Customer> _customers;

    public InMemoryCustomerRepository(IEnumerable<Customer> customers)
    {
        _customers = customers.ToDictionary(p => p.CustomerId);
    }

    public void Add(Customer customer)
    {
        var id = _customers.Max(p => p.Key);

        customer.CustomerId = ++id;

        _customers.Add(customer.CustomerId, customer);
    }

    public Customer Get(int id)
    {
        return _customers[id];
    }


    public IEnumerable<Customer> GetAll()
    {
        return _customers.Values;
    }
}

// Szablon klasy (Klasa generyczny)
public class InMemoryEntityRepository<TEntity>
        where TEntity : BaseEntity
{
    private readonly IDictionary<int, TEntity> _entities;

    public InMemoryEntityRepository(IEnumerable<TEntity> entities)
    {
        _entities = entities.ToDictionary(p => p.Id);
    }

    public void Add(TEntity entity)
    {
        var id = _entities.Max(p => p.Key);

        entity.Id = ++id;

        _entities.Add(entity.Id, entity);
    }

    public TEntity Get(int id)
    {
        return _entities[id];
    }


    public IEnumerable<TEntity> GetAll()
    {
        return _entities.Values;
    }
}


public class InMemoryAccountRepository : InMemoryEntityRepository<Account>
{
    public InMemoryAccountRepository(IEnumerable<Account> entities) : base(entities)
    {
    }
}