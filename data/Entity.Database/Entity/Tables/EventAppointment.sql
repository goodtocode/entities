CREATE TABLE [Entity].[EventAppointment] (
    [EventAppointmentId]	INT IDENTITY (1, 1) CONSTRAINT [DF_EventAppointment_Id] NOT NULL,
    [EventAppointmentKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_EventAppointment_Key] DEFAULT(NewId()) NOT NULL,
    [EventKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_EventAppointment_EventId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [AppointmentKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_EventAppointment_AppointmentId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_EventAppointment_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_EventAppointment_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_EventAppointment_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EventAppointment] PRIMARY KEY CLUSTERED ([EventAppointmentId] ASC),
    CONSTRAINT [FK_EventAppointment_Event] FOREIGN KEY ([EventKey]) REFERENCES [Entity].[Event] ([EventKey]),
    CONSTRAINT [FK_EventAppointment_Appointment] FOREIGN KEY ([AppointmentKey]) REFERENCES [Entity].[Appointment] ([AppointmentKey]),
    CONSTRAINT [FK_EventAppointment_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventAppointment_Key] ON [Entity].[EventAppointment] ([EventAppointmentKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventAppointment_All] ON [Entity].[EventAppointment] ([EventKey] Asc, [AppointmentKey] Asc)
GO
