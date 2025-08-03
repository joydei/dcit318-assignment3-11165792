using System;

public class BankTransferProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[Bank Transfer] Processing a transaction of GHC{transaction.Amount:F2} for '{transaction.Category}'.");
    }
}