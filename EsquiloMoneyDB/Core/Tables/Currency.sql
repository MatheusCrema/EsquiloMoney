CREATE TABLE [Core].[Currency] (
    [CurrencyID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (20)  NOT NULL,
    [Code]       VARCHAR (5)   NOT NULL,
    [Country]    VARCHAR (30)  NOT NULL,
    [CreatedDT]  DATETIME2 (7) CONSTRAINT [DF_Currency_CreatedDT] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Currency_CurrencyID] PRIMARY KEY CLUSTERED ([CurrencyID] ASC),
    CONSTRAINT [IX_Currency_Code] UNIQUE NONCLUSTERED ([Code] ASC)
);

