CREATE TABLE [raw].[Transactions_Raw_Old_csv_ZZZ] (
    [Date]        VARCHAR (50)     NULL,
    [Cod]         NVARCHAR (50)    NULL,
    [Category]    NVARCHAR (50)    NULL,
    [SubCategory] NVARCHAR (MAX)   NULL,
    [Payment]     NVARCHAR (50)    NULL,
    [Name]        NVARCHAR (50)    NULL,
    [Value]       DECIMAL (18, 10) NULL,
    [Type]        NVARCHAR (50)    NULL,
    [Comment]     NVARCHAR (250)   NULL
);

