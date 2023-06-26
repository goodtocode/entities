CREATE TABLE [Entity].[VentureResource] (
    [VentureResourceId]	INT IDENTITY (1, 1) CONSTRAINT [DF_VentureResource_Id] NOT NULL,
    [VentureResourceKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_VentureResource_Key] DEFAULT(NewId()) NOT NULL,
    [VentureKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_VentureResource_VentureId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ResourceKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_VentureResource_ResourceId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ResourceTypeKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_VentureResource_ResourceTypeId] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_VentureResource_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_VentureResource_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_VentureResource_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_VentureResource] PRIMARY KEY CLUSTERED ([VentureResourceId] ASC),
    CONSTRAINT [FK_VentureResource_Resource] FOREIGN KEY ([ResourceKey]) REFERENCES [Entity].[Resource] ([ResourceKey]),
    CONSTRAINT [FK_VentureResource_ResourceType] FOREIGN KEY ([ResourceTypeKey]) REFERENCES [Entity].[ResourceType] ([ResourceTypeKey]),
    CONSTRAINT [FK_VentureResource_Venture] FOREIGN KEY ([VentureKey]) REFERENCES [Entity].[Venture] ([VentureKey]),
    CONSTRAINT [FK_VentureResource_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureResource_Key] ON [Entity].[VentureResource] ([VentureResourceKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureResource_All] ON [Entity].[VentureResource] ([VentureKey] Asc, [ResourceKey] Asc)
GO
