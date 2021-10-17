CREATE TABLE [Core].[Institution] (
    [InstitutionID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (20)  NOT NULL,
    [CreatedDT]     DATETIME2 (7) CONSTRAINT [DF_Institution_CreateDT] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Institution_InstitutionID] PRIMARY KEY CLUSTERED ([InstitutionID] ASC),
    CONSTRAINT [IX_Institution_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

