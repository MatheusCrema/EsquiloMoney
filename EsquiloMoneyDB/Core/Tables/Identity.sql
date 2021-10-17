CREATE TABLE [Core].[Identity] (
    [IdentityID] INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (50)  NOT NULL,
    [LastName]   VARCHAR (50)  NOT NULL,
    [Email]      VARCHAR (200) NOT NULL,
    [CreatedDT]  DATETIME2 (7) CONSTRAINT [DF_Identity_CreatedDT] DEFAULT (getdate()) NOT NULL,
    [Phone]      VARCHAR (25)  NULL,
    CONSTRAINT [PK_Identity_IdentityID] PRIMARY KEY CLUSTERED ([IdentityID] ASC),
    CONSTRAINT [IX_Identity_Email] UNIQUE NONCLUSTERED ([Email] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Identity_FirstLastName]
    ON [Core].[Identity]([FirstName] ASC, [LastName] ASC);

