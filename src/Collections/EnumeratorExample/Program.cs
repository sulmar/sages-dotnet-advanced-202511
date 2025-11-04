
using EnumeratorExample;

Console.WriteLine("Hello, Enumerator!");


CircularList<int> numbers = new CircularList<int>( [1, 2, 3, 4, 5, 6, 7, 8, 9, 10] );

var subset = numbers.Where(n => n > 5).ToList();

foreach (int number in numbers.Take(3))
{
    Console.WriteLine(number);
}


Customer customer = new Customer { Id = 1, FirstName = "John", LastName = "Smith" };

foreach(var property in customer)
{
    Console.WriteLine(property);
}

Console.WriteLine("=== GetDaysOfWeek");
foreach(var dayOfWeek in DateHelper.GetDaysOfWeekByYield())
{
    if (dayOfWeek == "pt")
        break; 

    Console.WriteLine(dayOfWeek); 
}

foreach (var day in DateHelper.GetWeekend())
{
    Console.WriteLine(day);
}

IList<int> happyNumbers = [10, 20, 30];

foreach (var number in happyNumbers)
{
    Console.WriteLine(number);
}
