using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusExample;

// zbior regul udawania danych

// dotnet add package Bogus
public class CustomerFaker : Faker<Customer>
{
    public CustomerFaker()
    {               
        UseSeed(11);
        StrictMode(true);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.FirstName, f => f.Person.FirstName);
        RuleFor(p => p.LastName, f => f.Person.LastName);
        RuleFor(p => p.Email, (f, c) => $"{c.FirstName}.{c.LastName}@example.com");

        Ignore(p => p.Nip);
        Ignore(p => p.Pesel);

        RuleFor(p => p.Salary, f => f.Random.Decimal(100, 2000));

        RuleFor(p => p.Birthday, f => f.Date.Past(20));

        RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
    }
}
