using ActivatorExample;

Console.WriteLine("Hello, Reflection Activator!");

Printer printer = new Printer();
Scanner scanner = new Scanner();

Queue<ICommand> commands = new Queue<ICommand>();

commands.Enqueue(new PrintCommand("Hello World!", 3));
commands.Enqueue(new PrintCommand("Hello Poland!"));
commands.Enqueue(new ScanCommand("scan1.png"));

while(commands.Count > 0)
{
    ICommand command = commands.Dequeue();

    command.Execute();
}


return;


BankAccount account = new BankAccount(1000); // Początkowy stan konta 1000
CommandInvoker invoker = new CommandInvoker(account);

// Wykonanie poleceń
invoker.ExecuteCommand("Deposit", 100); // Wpłata 100
invoker.ExecuteCommand("Withdraw", 50);  // Wypłata 50
invoker.ExecuteCommand("Withdraw", 200); // Wypłata 200
invoker.ExecuteCommand("NonExistent", 100); // To powinno zwrócić błąd