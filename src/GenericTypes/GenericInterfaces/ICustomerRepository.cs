namespace GenericTypes;

public class Customer
{
    public int CustomerId { get; set; }
    public required string Name { get; set; }
}

public class User
{
    public int UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
}

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAllCustomers();
    Customer GetCustomer(int id);
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void RemoveCustomer(Customer customer);
}

// TODO: Add IUserRepository