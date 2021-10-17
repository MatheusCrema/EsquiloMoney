CREATE TABLE [Core].[PaymentType] (
    [PaymentTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (20)  NOT NULL,
    [Description]   VARCHAR (255) NOT NULL,
    [CreatedDT]     DATETIME2 (7) CONSTRAINT [DF_PaymentType_CreatedDT] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PaymentType_PaymentTypeID] PRIMARY KEY CLUSTERED ([PaymentTypeID] ASC),
    CONSTRAINT [IX_PaymentType_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

