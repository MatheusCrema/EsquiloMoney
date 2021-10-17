CREATE TABLE [Core].[Transaction] (
    [TransactionID]      INT            IDENTITY (1, 1) NOT NULL,
    [Type]               VARCHAR (7)    NOT NULL,
    [Date]               DATETIME2 (7)  CONSTRAINT [DF_Transaction_Date] DEFAULT (getdate()) NOT NULL,
    [Name]               NVARCHAR (140) NOT NULL,
    [Value]              DECIMAL (18)   CONSTRAINT [DF_Transaction_Value] DEFAULT ((0)) NOT NULL,
    [Comment]            NVARCHAR (255) NULL,
    [OriginalCurrencyID] INT            NOT NULL,
    [OriginalValue]      DECIMAL (18)   NULL,
    [CategoryID]         INT            NOT NULL,
    [PaymentTypeID]      INT            NOT NULL,
    [AccountID]          INT            NOT NULL,
    [CreatedDT]          DATETIME2 (7)  CONSTRAINT [DF_Transaction_CreatedDT] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Transaction_TransactionID] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [CK_Transaction_Type] CHECK ([Type]='Expense' OR [Type]='Income'),
    CONSTRAINT [FK_Transaction_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [Core].[Account] ([AccountID]),
    CONSTRAINT [FK_Transaction_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Core].[Category] ([CategoryID]),
    CONSTRAINT [FK_Transaction_OriginalCurrencyID] FOREIGN KEY ([OriginalCurrencyID]) REFERENCES [Core].[Currency] ([CurrencyID]),
    CONSTRAINT [FK_Transaction_PaymentTypeID] FOREIGN KEY ([PaymentTypeID]) REFERENCES [Core].[PaymentType] ([PaymentTypeID]),
    CONSTRAINT [IX_Transaction_Unique] UNIQUE NONCLUSTERED ([Type] ASC, [Date] ASC, [Name] ASC, [Value] ASC, [AccountID] ASC)
);

