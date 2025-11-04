
using Delegates;

Console.WriteLine("Hello Delegates!");

var printer = new Printer();

// printer.Log = LogToConsole;
//printer.Log += LogToFile;
//printer.Log += LogToDb;

printer.Print("Hello World!");



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