using MetaDataExample;

Console.WriteLine("Hello, Reflection!");

// TODO: Wypisz nazwy właściwości klasy Customer

Customer customer = new Customer();

customer.PropertyChanged += Customer_PropertyChanged;

void Customer_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
{
    throw new NotImplementedException();
}



customer.PropertyChanged -= Customer_PropertyChanged;


Type type = typeof(Customer);

var builder = new DocumentationBuilder();

// Fluent Api (Chaining Methods) - sposob implementacji wzorca budownicznego
var output = builder
    .WithType(type)
    .GenerateHeader()
    .GenerateProperties()
    .GenerateConstructors()
    .GenerateMethods()
    .GenerateEvents()
    .GenerateFooter()
    .Build();

Console.WriteLine(output);

