using ActivatorExample;

Console.WriteLine("Hello, Reflection Activator!");


BankAccount account = new BankAccount(1000); // Początkowy stan konta 1000
CommandInvoker invoker = new CommandInvoker(account);

// Wykonanie poleceń
invoker.ExecuteCommand("Deposit", 100); // Wpłata 100
invoker.ExecuteCommand("Withdraw", 50);  // Wypłata 50
invoker.ExecuteCommand("Withdraw", 200); // Wypłata 200
invoker.ExecuteCommand("NonExistent", 100); // To powinno zwrócić błąd