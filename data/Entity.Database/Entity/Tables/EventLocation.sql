CREATE TABLE [Entity].[EventLocation] (
    [EventLocationId]	INT IDENTITY (1, 1) CONSTRAINT [DF_EventLocation_Id] NOT NULL,
    [EventLocationKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_EventLocation_Key] DEFAULT(NewId()) NOT NULL,
    [EventKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_EventLocation_EventId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [LocationKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_EventLocation_LocationId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [LocationTypeKey]			UNIQUEIDENTIFIER    CONSTRAINT [DF_EventLocation_LocationType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_EventLocation_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_EventLocation_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_EventLocation_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EventLocation] PRIMARY KEY CLUSTERED ([EventLocationId] ASC),
    CONSTRAINT [FK_EventLocation_Event] FOREIGN KEY ([EventKey]) REFERENCES [Entity].[Event] ([EventKey]),
    CONSTRAINT [FK_EventLocation_Location] FOREIGN KEY ([LocationKey]) REFERENCES [Entity].[Location] ([LocationKey]),
    CONSTRAINT [FK_EventLocation_LocationType] FOREIGN KEY ([LocationTypeKey]) REFERENCES [Entity].[LocationType] ([LocationTypeKey]),    
    CONSTRAINT [FK_EventLocation_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventLocation_Key] ON [Entity].[EventLocation] ([EventLocationKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventLocation_All] ON [Entity].[EventLocation] ([EventKey] Asc, [LocationKey] Asc)
GO
