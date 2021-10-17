CREATE TABLE [Core].[CategoryBalance] (
    [CategoryBalanceID] INT           IDENTITY (1, 1) NOT NULL,
    [Period]            VARCHAR (20)  NOT NULL,
    [DateReference]     DATETIME2 (7) CONSTRAINT [DF_CategoryBalance_DateReference] DEFAULT (getdate()) NOT NULL,
    [TotalExpense]      DECIMAL (18)  CONSTRAINT [DF_CategoryBalance_TotalExpense] DEFAULT ((0)) NOT NULL,
    [PlannedExpense]    DECIMAL (18)  CONSTRAINT [DF_CategoryBalance_PlannedExpense] DEFAULT ((0)) NOT NULL,
    [CreatedDT]         DATETIME2 (7) CONSTRAINT [DF_CategoryBalance_CreatedDT] DEFAULT (getdate()) NOT NULL,
    [CategoryID]        INT           NOT NULL,
    CONSTRAINT [PK_CategoryBalance_CategoryBalanceID] PRIMARY KEY CLUSTERED ([CategoryBalanceID] ASC),
    CONSTRAINT [FK_CategoryBalance_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Core].[Category] ([CategoryID])
);

