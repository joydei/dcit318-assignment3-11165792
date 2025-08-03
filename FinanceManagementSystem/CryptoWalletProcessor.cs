using System;

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[Crypto Wallet] Processing a transaction of GHC{transaction.Amount:F2} for '{transaction.Category}'.");
    }
}