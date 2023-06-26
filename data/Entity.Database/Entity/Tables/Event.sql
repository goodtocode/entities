CREATE TABLE [Entity].[Event] (
    [EventId]          INT IDENTITY (1, 1) CONSTRAINT [DF_Event_EventId] NOT NULL,
	[EventKey]          UNIQUEIDENTIFIER CONSTRAINT [DF_Event_EventKey] DEFAULT (NewID()) NOT NULL,
    [EventGroupKey]     UNIQUEIDENTIFIER CONSTRAINT [DF_Event_EventGroup] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [EventTypeKey]      UNIQUEIDENTIFIER CONSTRAINT [DF_Event_EventType] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [EventCreatorKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_Event_EventCreator] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [EventName]        NVARCHAR (50)    CONSTRAINT [DF_Event_EventName] DEFAULT ('') NOT NULL,
    [EventDescription] NVARCHAR (250)   CONSTRAINT [DF_Event_EventDescription] DEFAULT ('') NOT NULL,
    [EventSlogan]      NVARCHAR (50)    CONSTRAINT [DF_Event_EventSlogan] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Event_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_Event_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Event_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,    
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventId] ASC),
    CONSTRAINT [FK_Event_Entity] FOREIGN KEY ([EventCreatorKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_Event_EventGroup] FOREIGN KEY ([EventGroupKey]) REFERENCES [Entity].[EventGroup] ([EventGroupKey]),
    CONSTRAINT [FK_Event_EventType] FOREIGN KEY ([EventTypeKey]) REFERENCES [Entity].[EventType] ([EventTypeKey]),
    CONSTRAINT [FK_Event_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE NonCLUSTERED INDEX [IX_Event_All] ON [Entity].[Event] ([EventGroupKey] Asc, [EventCreatorKey] Asc, [EventName] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Event_EventKey] ON [Entity].[Event] ([EventKey] Asc)
GO