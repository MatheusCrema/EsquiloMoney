CREATE TABLE [Core].[Account] (
    [AccountID]     INT           IDENTITY (1, 1) NOT NULL,
    [Number]        VARCHAR (50)  NOT NULL,
    [ExpireDT]      DATETIME      NULL,
    [CreatedDT]     DATETIME2 (7) CONSTRAINT [DF_Account_CreatedDT] DEFAULT (getdate()) NOT NULL,
    [IdentityID]    INT           NOT NULL,
    [InstitutionID] INT           NOT NULL,
    CONSTRAINT [PK_Account_AccountID] PRIMARY KEY CLUSTERED ([AccountID] ASC),
    CONSTRAINT [FK_Account_IdentityID] FOREIGN KEY ([IdentityID]) REFERENCES [Core].[Identity] ([IdentityID]),
    CONSTRAINT [FK_Account_InstitutionID] FOREIGN KEY ([InstitutionID]) REFERENCES [Core].[Institution] ([InstitutionID]),
    CONSTRAINT [IX_Account_Number] UNIQUE NONCLUSTERED ([Number] ASC)
);

