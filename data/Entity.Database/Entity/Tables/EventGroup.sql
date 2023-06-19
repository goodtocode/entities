CREATE TABLE [Entity].[EventGroup] (
    [EventGroupId]          INT IDENTITY (1, 1) CONSTRAINT [DF_EventGroup_EventGroupId] NOT NULL,
	[EventGroupKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_EventGroup_EventGroupKey] DEFAULT (NewID()) NOT NULL,
    [EventGroupName]        NVARCHAR (50)    CONSTRAINT [DF_EventGroup_EventGroupName] DEFAULT ('') NOT NULL,
    [EventGroupDescription] NVARCHAR (250)   CONSTRAINT [DF_EventGroup_EventGroupDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_EventGroup_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_EventGroup_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EventGroup] PRIMARY KEY CLUSTERED ([EventGroupId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventGroup_Key] ON [Entity].[EventGroup] ([EventGroupKey] Asc)
GO