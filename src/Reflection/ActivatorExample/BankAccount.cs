using System.Windows.Input;

namespace ActivatorExample;

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }
}

public class CommandFactory(BankAccount _account)
{
    public ICommand Create(string commandName, decimal amount)
    {
        switch (commandName)
        {
            case "Deposit":
                return new DepositCommand(_account, amount);
            case "Withdraw":
                return new WithdrawCommand(_account, amount);
            default:
                throw new NotSupportedException($"Command '{commandName}' not found.");
        }
    }
}

public class CommandInvoker
{
    private readonly BankAccount _account;
    private readonly CommandFactory factory;

    public CommandInvoker(BankAccount account, CommandFactory factory)
    {
        _account = account;
        this.factory = factory;
    }

    public void ExecuteCommand(string commandName, decimal amount)
    {
        ICommand command = factory.Create(commandName, amount);

        command.Execute();

    }
}

// Wzorzec Command


public class DepositCommand : ICommand
{
    private readonly BankAccount _account;
    private readonly decimal _amount;

    public DepositCommand(BankAccount account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _account.Deposit(_amount);
        Console.WriteLine($"Deposited {_amount} to account. New balance: {_account.Balance}");
    }
}

public class WithdrawCommand : ICommand
{
    private readonly BankAccount _account;
    private readonly decimal _amount;

    public WithdrawCommand(BankAccount account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        if (_account.Withdraw(_amount))
        {
            Console.WriteLine($"Withdrew {_amount} from account. New balance: {_account.Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds for withdrawal.");
        }
    }
}