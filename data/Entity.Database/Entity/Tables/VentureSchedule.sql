CREATE TABLE [Entity].[VentureSchedule] (
    [VentureScheduleId]	INT IDENTITY (1, 1) CONSTRAINT [DF_VentureSchedule_Id] NOT NULL,
    [VentureScheduleKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_VentureSchedule_Key] DEFAULT(NewId()) NOT NULL,
    [VentureKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_VentureSchedule_VentureId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ScheduleKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_VentureSchedule_ScheduleId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ScheduleTypeKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_VentureSchedule_ScheduleTypeId] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_VentureSchedule_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_VentureSchedule_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_VentureSchedule_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_VentureSchedule] PRIMARY KEY CLUSTERED ([VentureScheduleId] ASC),
    CONSTRAINT [FK_VentureSchedule_Schedule] FOREIGN KEY ([ScheduleKey]) REFERENCES [Entity].[Schedule] ([ScheduleKey]),
    CONSTRAINT [FK_VentureSchedule_ScheduleType] FOREIGN KEY ([ScheduleTypeKey]) REFERENCES [Entity].[ScheduleType] ([ScheduleTypeKey]),
    CONSTRAINT [FK_VentureSchedule_Venture] FOREIGN KEY ([VentureKey]) REFERENCES [Entity].[Venture] ([VentureKey]),
    CONSTRAINT [FK_VentureSchedule_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureSchedule_Key] ON [Entity].[VentureSchedule] ([VentureScheduleKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureSchedule_All] ON [Entity].[VentureSchedule] ([VentureKey] Asc, [ScheduleKey] Asc)
GO
