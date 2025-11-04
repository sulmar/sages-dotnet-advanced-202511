// See https://aka.ms/new-console-template for more information
using ConsoleApp;
using ConsoleApp.Helpers;

Console.WriteLine("Hello, World!");


if (DateTime.Today.IsWeekend())
{
    Console.WriteLine("juz weekend!");
}
else
    Console.WriteLine("dzien roboczy ©.".RemovePolishLetters());


Console.WriteLine( DateTime.Today.AddWorkDays(2));


