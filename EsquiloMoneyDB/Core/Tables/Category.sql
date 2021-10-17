CREATE TABLE [Core].[Category] (
    [CategoryID]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (20)  NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    [Hierarchy]        INT           CONSTRAINT [DF_Category_Hierarchy] DEFAULT ((0)) NOT NULL,
    [CategoryParentID] INT           NULL,
    [IconUI]           VARCHAR (100) NULL,
    [CreatedDT]        DATETIME2 (7) CONSTRAINT [DF_Category_CreatedDT] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Category_CategoryID] PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [FK_Category_CategoryParentID] FOREIGN KEY ([CategoryParentID]) REFERENCES [Core].[Category] ([CategoryID]),
    CONSTRAINT [IX_Category_Name] UNIQUE NONCLUSTERED ([Name] ASC, [CategoryParentID] ASC)
);

