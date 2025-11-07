// See https://aka.ms/new-console-template for more information
using DynamicObjectExample;
using System.Net.Http.Headers;

Console.WriteLine("Hello, Dynamic Object!");

object?[] numbers = { 1, 2, 3, null };

dynamic obj = new MyDynamic();

obj.Message = "Hello World!";

Console.WriteLine(obj.Message);

var result = obj.Test(1, 2, 3);

Console.WriteLine(result);

Console.WriteLine(obj.Dump());

dynamic api = new Api();

Console.WriteLine(api.Users);
Console.WriteLine(api.Products);

dynamic path = new DynamicPath();

Console.WriteLine(path.api.Users.List);