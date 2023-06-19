CREATE TABLE [Entity].[VentureAppointment] (
    [VentureAppointmentId]	INT IDENTITY (1, 1) CONSTRAINT [DF_VentureAppointment_Id] NOT NULL,
    [VentureAppointmentKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_VentureAppointment_Key] DEFAULT(NewId()) NOT NULL,
    [VentureKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_VentureAppointment_VentureId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [AppointmentKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_VentureAppointment_AppointmentId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_VentureAppointment_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_VentureAppointment_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_VentureAppointment_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_VentureAppointment] PRIMARY KEY CLUSTERED ([VentureAppointmentId] ASC),
    CONSTRAINT [FK_VentureAppointment_Venture] FOREIGN KEY ([VentureKey]) REFERENCES [Entity].[Venture] ([VentureKey]),
    CONSTRAINT [FK_VentureAppointment_Appointment] FOREIGN KEY ([AppointmentKey]) REFERENCES [Entity].[Appointment] ([AppointmentKey]),
    CONSTRAINT [FK_VentureAppointment_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureAppointment_Key] ON [Entity].[VentureAppointment] ([VentureAppointmentKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureAppointment_All] ON [Entity].[VentureAppointment] ([VentureKey] Asc, [AppointmentKey] Asc)
GO
