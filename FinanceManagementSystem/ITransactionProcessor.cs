using System;

public interface ITransactionProcessor
{
    void Process(Transaction transaction);
}