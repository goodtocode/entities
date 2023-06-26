CREATE TABLE [Entity].[EntityLocation] (
    [EntityLocationId]	        INT IDENTITY (1, 1) CONSTRAINT [DF_EntityLocation_Entity] NOT NULL,
	[EntityLocationKey]		    UNIQUEIDENTIFIER				CONSTRAINT [DF_EntityLocation_Entity] DEFAULT(NewId()) NOT NULL,	
    [EntityKey]             UNIQUEIDENTIFIER    CONSTRAINT [DF_EntityLocation_EntityKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [LocationKey]			UNIQUEIDENTIFIER    CONSTRAINT [DF_EntityLocation_LocationKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [LocationTypeKey]		UNIQUEIDENTIFIER    CONSTRAINT [DF_EntityLocation_LocationType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER    CONSTRAINT [DF_EntityLocation_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]	        DATETIME         CONSTRAINT [DF_EntityLocation_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]	        DATETIME         CONSTRAINT [DF_EntityLocation_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EntityLocation] PRIMARY KEY CLUSTERED ([EntityLocationId] ASC),
	CONSTRAINT [FK_EntityLocation_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_EntityLocation_Location] FOREIGN KEY ([LocationKey]) REFERENCES [Entity].[Location] ([LocationKey]),
    CONSTRAINT [FK_EntityLocation_LocationType] FOREIGN KEY ([LocationTypeKey]) REFERENCES [Entity].[LocationType] ([LocationTypeKey]),
    CONSTRAINT [FK_EntityLocation_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityLocation_Entity] ON [Entity].[Entity] ([EntityKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityLocation_All] ON [Entity].[EntityLocation] ([EntityKey] Asc, [LocationKey] Asc)
GO