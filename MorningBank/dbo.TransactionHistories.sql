CREATE TABLE [dbo].[TransactionHistories] (
    [TransactionId]         BIGINT   NOT NULL IDENTITY,
    [TransactionDate]       DATETIME NOT NULL,
    [CheckingAccountNumber] BIGINT   NOT NULL,
    [SavingAccountNumber]   BIGINT   NOT NULL,
    [Amount]                MONEY    NOT NULL,
    [Transactionfee]        MONEY    NOT NULL,
    [TransactionTypeId]     BIGINT   NOT NULL,
    CONSTRAINT [PK_TransactionHistories] PRIMARY KEY CLUSTERED ([TransactionId] ASC)
);

