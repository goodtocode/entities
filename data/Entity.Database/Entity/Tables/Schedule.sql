CREATE TABLE [Entity].[Schedule] (
    [ScheduleId]        INT IDENTITY (1, 1) CONSTRAINT [DF_Schedule_ScheduleId] NOT NULL,
	[ScheduleKey]       UNIQUEIDENTIFIER CONSTRAINT [DF_Schedule_ScheduleKey] DEFAULT(NewId()) NOT NULL,
    [ScheduleName]			NVARCHAR (50)    CONSTRAINT [DF_Schedule_ScheduleName] DEFAULT ('') NOT NULL,
    [ScheduleDescription]	NVARCHAR (2000)   CONSTRAINT [DF_Schedule_ScheduleDescription] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Schedule_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]       DATETIME         CONSTRAINT [DF_Schedule_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]      DATETIME         CONSTRAINT [DF_Schedule_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED ([ScheduleId] ASC),
    CONSTRAINT [FK_Schedule_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Schedule_ScheduleKey] ON [Entity].[Schedule] ([ScheduleKey] Asc)
GO