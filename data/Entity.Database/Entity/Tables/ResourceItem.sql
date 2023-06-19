CREATE TABLE [Entity].[ResourceItem] (
    [ResourceItemId]		INT IDENTITY (1, 1) CONSTRAINT [DF_ResourceItem_ResourceItemId] NOT NULL,
    [ResourceItemKey]     UNIQUEIDENTIFIER CONSTRAINT [DF_ResourceItem_ResourceItemKey] DEFAULT(NewId()) NOT NULL,
	[ResourceKey]			UNIQUEIDENTIFIER         CONSTRAINT [DF_ResourceItem_Resource] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[ItemKey]				UNIQUEIDENTIFIER         CONSTRAINT [DF_ResourceItem_Item] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER         CONSTRAINT [DF_ResourceItem_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_ResourceItem_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_ResourceItem_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ResourceItem] PRIMARY KEY CLUSTERED ([ResourceItemId] ASC),
	CONSTRAINT [FK_ResourceItem_Resource] FOREIGN KEY ([ResourceKey]) REFERENCES [Entity].[Resource] ([ResourceKey]),
    CONSTRAINT [FK_ResourceItem_Item] FOREIGN KEY ([ItemKey]) REFERENCES [Entity].[Item] ([ItemKey]),
    CONSTRAINT [FK_ResourceItem_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ResourceItem_Key] ON [Entity].[ResourceItem] ([ResourceItemKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ResourceItem_Resource] ON [Entity].[ResourceItem] ([ResourceKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ResourceItem_Item] ON [Entity].[ResourceItem] ([ItemKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ResourceItem_All] ON [Entity].[ResourceItem] ([ResourceKey] Asc, [ItemKey] Asc)
GO