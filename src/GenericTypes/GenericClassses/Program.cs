using GenericClassses;

Console.WriteLine("Hello, Generic Classes!");

var customers = new List<Customer>
{
    new Customer { CustomerId = 1, Name = "Microsoft" },
    new Customer { CustomerId = 2, Name = "Google" },
    new Customer { CustomerId = 3, Name = "Apple" },
};

var accounts = new List<Account>
{
    new Account { AccountId = 1, Number = "11110000", Balance = 100},
    new Account { AccountId = 2, Number = "22220000", Balance = 200 },
    new Account { AccountId = 3, Number = "33330000", Balance = 300 },
    new Account { AccountId = 4, Number = "44440000", Balance = 400 },
    new Account { AccountId = 5, Number = "66660000", Balance = 500 },
};

InMemoryCustomerRepository repository = new InMemoryCustomerRepository(customers);

var customer = repository.GetCustomer(1);

Console.WriteLine(customer);