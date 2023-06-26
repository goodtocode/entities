CREATE TABLE [Entity].[EventType] (
    [EventTypeId]           INT IDENTITY (1, 1) CONSTRAINT [DF_EventType_EventTypeId] NOT NULL,
	[EventTypeKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_EventType_EventTypeKey] DEFAULT (NewID()) NOT NULL,
    [EventGroupKey]         UNIQUEIDENTIFIER CONSTRAINT [DF_EventType_EventGroupId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [EventTypeName]         NVARCHAR (50)    CONSTRAINT [DF_EventType_EventTypeName] DEFAULT ('') NOT NULL,
    [EventTypeDescription]  NVARCHAR (250)   CONSTRAINT [DF_EventType_EventTypeDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_EventType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_EventType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED ([EventTypeId] ASC),
    CONSTRAINT [FK_EventType_EventGroup] FOREIGN KEY ([EventGroupKey]) REFERENCES [Entity].[EventGroup] ([EventGroupKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventType_Key] ON [Entity].[EventType] ([EventTypeKey] Asc)
GO