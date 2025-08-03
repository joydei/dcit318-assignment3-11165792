using System;

public class MobileMoneyProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[Mobile Money] Processing a transaction of GHC{transaction.Amount:F2} for '{transaction.Category}'.");
    }
}