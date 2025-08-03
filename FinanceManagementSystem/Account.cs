using System;

public class Account
{
    public string AccountNumber { get; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        Console.WriteLine($"Account {AccountNumber} created with initial balance: GHC{Balance:F2}");
    }

    public virtual void ApplyTransaction(Transaction transaction)
    {
        Balance -= transaction.Amount;
        Console.WriteLine($"Transaction applied. New balance for account {AccountNumber}: GHC{Balance:F2}");
    }
}