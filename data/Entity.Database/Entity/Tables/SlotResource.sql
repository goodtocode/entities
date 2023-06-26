CREATE TABLE [Entity].[SlotResource] (
    [SlotResourceId]    INT IDENTITY (1, 1) CONSTRAINT [DF_SlotResource_SlotResourceId] NOT NULL,
    [SlotResourceKey]	UNIQUEIDENTIFIER	CONSTRAINT [DF_SlotResource_SlotResourceKey] DEFAULT(NewId()) NOT NULL,
	[SlotKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotResource_SlotId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[ResourceKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotResource_ResourceId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ResourceTypeKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotResource_ResourceType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_SlotResource_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_SlotResource_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_SlotResource_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_SlotResource] PRIMARY KEY CLUSTERED ([SlotResourceId] ASC),
	CONSTRAINT [FK_SlotResource_Slot] FOREIGN KEY ([SlotKey]) REFERENCES [Entity].[Slot] ([SlotKey]),
	CONSTRAINT [FK_SlotResource_Resource] FOREIGN KEY ([ResourceKey]) REFERENCES [Entity].[Resource] ([ResourceKey]),
    CONSTRAINT [FK_SlotResource_ResourceType] FOREIGN KEY ([ResourceTypeKey]) REFERENCES [Entity].[ResourceType] ([ResourceTypeKey]),
    CONSTRAINT [FK_SlotResource_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE NonCLUSTERED INDEX [IX_SlotResource_Slot] ON [Entity].[SlotResource] ([SlotKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_SlotResource_Resource] ON [Entity].[SlotResource] ([ResourceKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_SlotResource_All] ON [Entity].[SlotResource] ([ResourceKey] Asc, [SlotKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_SlotResource_SlotResourceKey] ON [Entity].[SlotResource] ([SlotResourceKey] Asc)
Go