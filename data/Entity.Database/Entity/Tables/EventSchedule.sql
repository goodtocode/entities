CREATE TABLE [Entity].[EventSchedule] (
    [EventScheduleId]	INT IDENTITY (1, 1) CONSTRAINT [DF_EventSchedule_Id] NOT NULL,
    [EventScheduleKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_EventSchedule_Key] DEFAULT(NewId()) NOT NULL,
    [EventKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_EventSchedule_EventId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ScheduleKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_EventSchedule_ScheduleId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ScheduleTypeKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_EventSchedule_ScheduleTypeId] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_EventSchedule_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_EventSchedule_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_EventSchedule_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EventSchedule] PRIMARY KEY CLUSTERED ([EventScheduleId] ASC),
    CONSTRAINT [FK_EventSchedule_Schedule] FOREIGN KEY ([ScheduleKey]) REFERENCES [Entity].[Schedule] ([ScheduleKey]),
    CONSTRAINT [FK_EventSchedule_ScheduleType] FOREIGN KEY ([ScheduleTypeKey]) REFERENCES [Entity].[ScheduleType] ([ScheduleTypeKey]),
    CONSTRAINT [FK_EventSchedule_Event] FOREIGN KEY ([EventKey]) REFERENCES [Entity].[Event] ([EventKey]),
    CONSTRAINT [FK_EventSchedule_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventSchedule_Key] ON [Entity].[EventSchedule] ([EventScheduleKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventSchedule_All] ON [Entity].[EventSchedule] ([EventKey] Asc, [ScheduleKey] Asc)
GO
