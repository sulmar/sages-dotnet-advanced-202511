
using Delegates;

Console.WriteLine("Hello Delegates!");

var printer = new Printer();

printer.Log = LogToConsole;
printer.Log += LogToFile;
printer.Log += LogToDb;
printer.Log += LogToWindow;
printer.Printed += Finish;

printer.Log += System.Console.WriteLine;

printer.CalculateCost = DiscountCalculateCost;

printer.Log.Invoke("HACK!");


printer.Print("Hello World!", 3);

printer.Log -= LogToDb;
printer.Print("Hello Europe!");


printer.Log = null;
printer.Print("Hello Poland!");


static void Finish(object sender, PrintedEventArgs args)
{
    Console.WriteLine($"Wydrukowano {args.Copies} kopii.");
}

static void LogToConsole(string message)
{
    Console.WriteLine(message);
}

static void LogToFile(string message)
{
    File.AppendAllText("log.txt", message);
}

static void LogToDb(string message)
{
    Console.WriteLine($"SQL: INSERT INTO Logs {message}");
}

static void LogToWindow(string message)
{
    Console.WriteLine($"WINDOW: {message}");
}

static decimal StandardCalculateCost(int copies, decimal cost)
{
    return copies * cost;
}

static decimal DiscountCalculateCost(int copies, decimal cost)
{
    return copies * cost - copies * cost * 0.1m;
}


