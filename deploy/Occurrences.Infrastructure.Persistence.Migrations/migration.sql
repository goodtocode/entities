IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    IF SCHEMA_ID(N'Occurrences') IS NULL EXEC(N'CREATE SCHEMA [Occurrences];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    IF SCHEMA_ID(N'Subjects') IS NULL EXEC(N'CREATE SCHEMA [Subjects];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[Appointment] (
        [AppointmentKey] uniqueidentifier NOT NULL,
        [AppointmentName] nvarchar(50) NOT NULL,
        [AppointmentDescription] nvarchar(2000) NULL,
        [SlotLocationKey] uniqueidentifier NULL,
        [SlotResourceKey] uniqueidentifier NULL,
        [TimeRangeKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Appointment] PRIMARY KEY ([AppointmentKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[AppointmentEvent] (
        [AppointmentEventKey] uniqueidentifier NOT NULL,
        [EventKey] uniqueidentifier NOT NULL,
        [AppointmentKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AppointmentEvent] PRIMARY KEY ([AppointmentEventKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[Event] (
        [EventKey] uniqueidentifier NOT NULL,
        [EventGroupKey] uniqueidentifier NOT NULL,
        [EventTypeKey] uniqueidentifier NOT NULL,
        [EventCreatorKey] uniqueidentifier NOT NULL,
        [EventName] nvarchar(50) NOT NULL,
        [EventDescription] nvarchar(250) NULL,
        [EventSlogan] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Event] PRIMARY KEY ([EventKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventAssociateOption] (
        [EventAssociateOptionKey] uniqueidentifier NOT NULL,
        [OptionKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [EventKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_EventAssociateOption] PRIMARY KEY ([EventAssociateOptionKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventDetail] (
        [EventDetailKey] uniqueidentifier NOT NULL,
        [EventKey] uniqueidentifier NOT NULL,
        [DetailKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_EventDetail] PRIMARY KEY ([EventDetailKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventGroup] (
        [EventGroupKey] uniqueidentifier NOT NULL,
        [EventGroupName] nvarchar(50) NOT NULL,
        [EventGroupDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_EventGroup] PRIMARY KEY ([EventGroupKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventLocation] (
        [EventLocationKey] uniqueidentifier NOT NULL,
        [EventKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_EventLocation] PRIMARY KEY ([EventLocationKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventOption] (
        [EventOptionKey] uniqueidentifier NOT NULL,
        [EventKey] uniqueidentifier NOT NULL,
        [OptionKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_EventOption] PRIMARY KEY ([EventOptionKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventResource] (
        [EventResourceKey] uniqueidentifier NOT NULL,
        [EventKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [ResourceTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_EventResource] PRIMARY KEY ([EventResourceKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventSchedule] (
        [EventScheduleKey] uniqueidentifier NOT NULL,
        [EventKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_EventSchedule] PRIMARY KEY ([EventScheduleKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Occurrences].[EventType] (
        [EventTypeKey] uniqueidentifier NOT NULL,
        [EventGroupKey] uniqueidentifier NOT NULL,
        [EventTypeName] nvarchar(50) NOT NULL,
        [EventTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_EventType] PRIMARY KEY ([EventTypeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Subjects].[AssociateAppointment] (
        [AssociateAppointmentKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [AppointmentKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AssociateAppointment] PRIMARY KEY ([AssociateAppointmentKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE TABLE [Subjects].[VentureAppointment] (
        [VentureAppointmentKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [AppointmentKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_VentureAppointment] PRIMARY KEY ([VentureAppointmentKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_Appointment_Key] ON [Occurrences].[Appointment] ([AppointmentKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationTime_All] ON [Occurrences].[Appointment] ([SlotLocationKey], [SlotResourceKey], [TimeRangeKey]) WHERE [SlotLocationKey] IS NOT NULL AND [SlotResourceKey] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_AppointmentEvent_Key] ON [Occurrences].[AppointmentEvent] ([AppointmentEventKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_AppointmentEvent_All] ON [Occurrences].[AppointmentEvent] ([EventKey], [AppointmentKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_Event_EventKey] ON [Occurrences].[Event] ([EventKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE INDEX [IX_Event_All] ON [Occurrences].[Event] ([EventGroupKey], [EventCreatorKey], [EventName]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventAssociateOption_Key] ON [Occurrences].[EventAssociateOption] ([EventAssociateOptionKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventDetail_Key] ON [Occurrences].[EventDetail] ([EventDetailKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventDetail_All] ON [Occurrences].[EventDetail] ([EventKey], [EventDetailKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventGroup_Key] ON [Occurrences].[EventGroup] ([EventGroupKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventLocation_Key] ON [Occurrences].[EventLocation] ([EventLocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventLocation_All] ON [Occurrences].[EventLocation] ([EventKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventOption_All] ON [Occurrences].[EventOption] ([EventKey], [OptionKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventResource_Key] ON [Occurrences].[EventResource] ([EventResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventResource_All] ON [Occurrences].[EventResource] ([EventKey], [ResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventSchedule_Key] ON [Occurrences].[EventSchedule] ([EventScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventSchedule_All] ON [Occurrences].[EventSchedule] ([EventKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_EventType_Key] ON [Occurrences].[EventType] ([EventTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateAppointment_Key] ON [Subjects].[AssociateAppointment] ([AssociateAppointmentKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateAppointment_All] ON [Subjects].[AssociateAppointment] ([AssociateKey], [AppointmentKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureAppointment_Key] ON [Subjects].[VentureAppointment] ([VentureAppointmentKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureAppointment_All] ON [Subjects].[VentureAppointment] ([VentureKey], [AppointmentKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043622_20200820-213614')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200821043622_20200820-213614', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822001009_20200821-171002')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200822001009_20200821-171002', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Subjects].[VentureAppointment] DROP CONSTRAINT [PK_VentureAppointment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Subjects].[AssociateAppointment] DROP CONSTRAINT [PK_AssociateAppointment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventType] DROP CONSTRAINT [PK_EventType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventSchedule] DROP CONSTRAINT [PK_EventSchedule];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventResource] DROP CONSTRAINT [PK_EventResource];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventOption] DROP CONSTRAINT [PK_EventOption];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventLocation] DROP CONSTRAINT [PK_EventLocation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventGroup] DROP CONSTRAINT [PK_EventGroup];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventDetail] DROP CONSTRAINT [PK_EventDetail];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventAssociateOption] DROP CONSTRAINT [PK_EventAssociateOption];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[Event] DROP CONSTRAINT [PK_Event];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[AppointmentEvent] DROP CONSTRAINT [PK_AppointmentEvent];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[Appointment] DROP CONSTRAINT [PK_Appointment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Subjects].[VentureAppointment] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Subjects].[AssociateAppointment] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventType] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventSchedule] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventResource] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventOption] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventLocation] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventGroup] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventDetail] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventAssociateOption] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Occurrences].[Event]') AND [c].[name] = N'EventSlogan');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Occurrences].[Event] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Occurrences].[Event] ALTER COLUMN [EventSlogan] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[Event] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[AppointmentEvent] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[Appointment] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Subjects].[VentureAppointment] ADD CONSTRAINT [PK_VentureAppointment] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Subjects].[AssociateAppointment] ADD CONSTRAINT [PK_AssociateAppointment] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventType] ADD CONSTRAINT [PK_EventType] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventSchedule] ADD CONSTRAINT [PK_EventSchedule] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventResource] ADD CONSTRAINT [PK_EventResource] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventOption] ADD CONSTRAINT [PK_EventOption] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventLocation] ADD CONSTRAINT [PK_EventLocation] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventGroup] ADD CONSTRAINT [PK_EventGroup] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventDetail] ADD CONSTRAINT [PK_EventDetail] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[EventAssociateOption] ADD CONSTRAINT [PK_EventAssociateOption] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[Event] ADD CONSTRAINT [PK_Event] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[AppointmentEvent] ADD CONSTRAINT [PK_AppointmentEvent] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    ALTER TABLE [Occurrences].[Appointment] ADD CONSTRAINT [PK_Appointment] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233348_20200904-163323')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200904233348_20200904-163323', N'3.1.7');
END;

GO

