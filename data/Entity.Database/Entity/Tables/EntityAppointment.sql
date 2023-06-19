CREATE TABLE [Entity].[EntityAppointment] (
    [EntityAppointmentId]	INT IDENTITY (1, 1) CONSTRAINT [DF_EntityAppointment_Id] NOT NULL,
    [EntityAppointmentKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_EntityAppointment_Key] DEFAULT(NewId()) NOT NULL,
    [EntityKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_EntityAppointment_EntityId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [AppointmentKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_EntityAppointment_AppointmentId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_EntityAppointment_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_EntityAppointment_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_EntityAppointment_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EntityAppointment] PRIMARY KEY CLUSTERED ([EntityAppointmentId] ASC),
    CONSTRAINT [FK_EntityAppointment_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_EntityAppointment_Appointment] FOREIGN KEY ([AppointmentKey]) REFERENCES [Entity].[Appointment] ([AppointmentKey]),
    CONSTRAINT [FK_EntityAppointment_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityAppointment_Key] ON [Entity].[EntityAppointment] ([EntityAppointmentKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityAppointment_All] ON [Entity].[EntityAppointment] ([EntityKey] Asc, [AppointmentKey] Asc)
GO
