namespace GenericClassses;

#region Models

public class Customer
{
    public int CustomerId { get; set; }
    public required string Name { get; set; }

    public override string ToString()
    {
        return $"CustomerId: {CustomerId} Name: {Name}";
    }
}

public class Account
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

    public void AddCustomer(Customer customer)
    {
        var id = _customers.Max(p => p.Key);

        customer.CustomerId = ++id;

        _customers.Add(customer.CustomerId, customer);
    }

    public Customer GetCustomer(int id)
    {
        return _customers[id];
    }


    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customers.Values;
    }
}


// TODO: Create InMemoryAccountRepository
