CREATE TABLE [Entity].[Resource] (
    [ResourceId]			INT IDENTITY (1, 1) CONSTRAINT [DF_Resource_ResourceId] NOT NULL,
	[ResourceKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_Resource_ResourceKey] DEFAULT(NewId()) NOT NULL,
	[ResourceName]			NVARCHAR (50)    CONSTRAINT [DF_Resource_ResourceName] DEFAULT ('') NOT NULL,
	[ResourceDescription]	NVARCHAR (250)   CONSTRAINT [DF_Resource_ResourceDescription] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Resource_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_Resource_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Resource_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED ([ResourceId] ASC),
    CONSTRAINT [FK_Resource_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Resource_ResourceKey] ON [Entity].[Resource] ([ResourceKey] Asc)
GO