using System;

public sealed class SavingsAccount : Account
{
    public SavingsAccount(string accountNumber, decimal initialBalance) : base(accountNumber, initialBalance)
    {
    }

    public override void ApplyTransaction(Transaction transaction)
    {
        if (transaction.Amount > Balance)
        {
            Console.WriteLine($"[Account {AccountNumber}] Insufficient funds. Transaction for GHC{transaction.Amount:F2} failed.");
        }
        else
        {
            base.ApplyTransaction(transaction); // Call the base method to deduct the amount
        }
    }
}