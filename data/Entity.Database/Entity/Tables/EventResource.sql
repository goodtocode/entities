CREATE TABLE [Entity].[EventResource] (
    [EventResourceId]	INT IDENTITY (1, 1) CONSTRAINT [DF_EventResource_Id] NOT NULL,
    [EventResourceKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_EventResource_Key] DEFAULT(NewId()) NOT NULL,
    [EventKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_EventResource_EventId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ResourceKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_EventResource_ResourceId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ResourceTypeKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_EventResource_ResourceTypeId] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_EventResource_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_EventResource_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_EventResource_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EventResource] PRIMARY KEY CLUSTERED ([EventResourceId] ASC),
    CONSTRAINT [FK_EventResource_Resource] FOREIGN KEY ([ResourceKey]) REFERENCES [Entity].[Resource] ([ResourceKey]),
    CONSTRAINT [FK_EventResource_ResourceType] FOREIGN KEY ([ResourceTypeKey]) REFERENCES [Entity].[ResourceType] ([ResourceTypeKey]),
    CONSTRAINT [FK_EventResource_Event] FOREIGN KEY ([EventKey]) REFERENCES [Entity].[Event] ([EventKey]),
    CONSTRAINT [FK_EventResource_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventResource_Key] ON [Entity].[EventResource] ([EventResourceKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventResource_All] ON [Entity].[EventResource] ([EventKey] Asc, [ResourceKey] Asc)
GO
