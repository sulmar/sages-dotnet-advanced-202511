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

// Wzorzec projektowy Fabryka
public class CommandFactory(BankAccount _account)
{
    public ICommand Create(string commandName, decimal amount)
    {
        var @namespace = typeof(ICommand).Namespace;

        var type = Type.GetType($"{@namespace}.{commandName}Command");

        if (type == null)
            throw new NotSupportedException($"Command '{commandName}' not found.");

        if (!typeof(ICommand).IsAssignableFrom(type))
            throw new ArgumentException($"{commandName} nie implementuje ICommand");
        
        ICommand command = (ICommand) Activator.CreateInstance(type, _account, amount);
           
        return command;
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

public class CheckBalanceCommand : ICommand
{
    private readonly BankAccount account;

    public CheckBalanceCommand(BankAccount account)
    {
        this.account = account;
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}