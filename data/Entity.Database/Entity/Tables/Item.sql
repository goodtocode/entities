CREATE TABLE [Entity].[Item] (
    [ItemId]            INT IDENTITY (1, 1) CONSTRAINT [DF_Item_ItemId] NOT NULL,
	[ItemKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_Item_ItemKey] DEFAULT(NewId()) NOT NULL,
    [ItemName]			NVARCHAR (50)    CONSTRAINT [DF_Item_ItemName] DEFAULT ('') NOT NULL,
    [ItemDescription]	NVARCHAR (2000)   CONSTRAINT [DF_Item_ItemDescription] DEFAULT ('') NOT NULL,
    [ItemTypeKey]      UNIQUEIDENTIFIER CONSTRAINT [DF_Item_ItemType] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Item_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_Item_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_Item_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([ItemId] ASC),
    CONSTRAINT [FK_Item_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Item_ItemKey] ON [Entity].[Item] ([ItemKey] Asc)
GO