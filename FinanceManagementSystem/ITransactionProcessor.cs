using System;

public interface ITransactionProcessor
{
    void ProcessTransaction(Transaction transaction);
}