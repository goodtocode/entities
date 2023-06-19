CREATE TABLE [Entity].[Appointment] (
    [AppointmentId]         INT IDENTITY (1, 1) CONSTRAINT [DF_Appointment_AppointmentId] NOT NULL,
	[AppointmentKey]        UNIQUEIDENTIFIER CONSTRAINT [DF_Appointment_AppointmentKey] DEFAULT (NewID()) NOT NULL,
    [AppointmentName]			NVARCHAR (50)    CONSTRAINT [DF_Appointment_AppointmentName] DEFAULT ('') NOT NULL,
    [AppointmentDescription]	NVARCHAR (2000)   CONSTRAINT [DF_Appointment_AppointmentDescription] DEFAULT ('') NOT NULL,
	[SlotLocationKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_Appointment_SlotLocation] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [SlotResourceKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_Appointment_SlotResource] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
	[TimeRangeKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_Appointment_TimeRangeId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Appointment_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_Appointment_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_Appointment_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
	CONSTRAINT [FK_Appointment_Location] FOREIGN KEY ([SlotLocationKey]) REFERENCES [Entity].[SlotLocation] ([SlotLocationKey]),
    CONSTRAINT [FK_Appointment_Resource] FOREIGN KEY ([SlotResourceKey]) REFERENCES [Entity].[SlotResource] ([SlotResourceKey]),
	CONSTRAINT [FK_Appointment_TimeRange] FOREIGN KEY ([TimeRangeKey]) REFERENCES [Entity].[TimeRange] ([TimeRangeKey]),
    CONSTRAINT [FK_Appointment_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Appointment_Key] ON [Entity].[Appointment] ([AppointmentKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_LocationTime_All] ON [Entity].[Appointment] ([SlotLocationKey] Asc, [SlotResourceKey] Asc, [TimeRangeKey] Asc)
GO