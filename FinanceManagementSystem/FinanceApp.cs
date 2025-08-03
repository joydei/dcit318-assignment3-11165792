using System;
using System.Collections.Generic;

public class FinanceApp
{
    private List<Transaction> _transactions = new List<Transaction>();

    public void Run()
    {
        // i. Instantiate a SavingsAccount
        var myAccount = new SavingsAccount("SA-12345", 1000);

        // ii. Create three Transaction records
        var transaction1 = new Transaction(1, DateTime.Now, 150.00m, "Groceries");
        var transaction2 = new Transaction(2, DateTime.Now, 500.00m, "Utilities");
        var transaction3 = new Transaction(3, DateTime.Now, 700.00m, "Entertainment");

        Console.WriteLine("\n--- Processing Transactions ---");

        // iii. Use the processors to process each transaction
        ITransactionProcessor mobileMoney = new MobileMoneyProcessor();
        ITransactionProcessor bankTransfer = new BankTransferProcessor();
        ITransactionProcessor cryptoWallet = new CryptoWalletProcessor();
        
        mobileMoney.Process(transaction1);
        bankTransfer.Process(transaction2);
        cryptoWallet.Process(transaction3);

        Console.WriteLine("\n--- Applying Transactions to Account ---");
        
        // iv. Apply each transaction to the SavingsAccount
        myAccount.ApplyTransaction(transaction1);
        myAccount.ApplyTransaction(transaction2);
        myAccount.ApplyTransaction(transaction3); 

        // v. Add all transactions to the list
        _transactions.Add(transaction1);
        _transactions.Add(transaction2);
        _transactions.Add(transaction3);

        Console.WriteLine("\n--- Transaction History ---");
        foreach (var transaction in _transactions)
        {
            Console.WriteLine($"Transaction ID: {transaction.Id}, Amount: GHC{transaction.Amount:F2}, Category: {transaction.Category}");
        }
    }
}