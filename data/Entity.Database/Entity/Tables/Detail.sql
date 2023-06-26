CREATE TABLE [Entity].[Detail] (
    [DetailId]             INT IDENTITY (1, 1) CONSTRAINT [DF_Detail_Id] NOT NULL,
    [DetailKey]            UNIQUEIDENTIFIER CONSTRAINT [DF_Detail_Key] DEFAULT (NewID()) NOT NULL,
    [DetailTypeKey]        UNIQUEIDENTIFIER CONSTRAINT [DF_Detail_DetailType] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DetailData]            NVARCHAR (2000)  CONSTRAINT [DF_Detail_DetailData] DEFAULT ('') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_Detail_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_Detail_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED ([DetailId] ASC),
    CONSTRAINT [FK_Detail_DetailType] FOREIGN KEY ([DetailTypeKey]) REFERENCES [Entity].[DetailType] ([DetailTypeKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Detail_Key] ON [Entity].[Detail] ([DetailKey] Asc)
GO
