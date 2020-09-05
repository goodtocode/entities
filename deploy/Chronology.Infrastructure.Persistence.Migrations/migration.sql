IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Chronology') IS NULL EXEC(N'CREATE SCHEMA [Chronology];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[AssociateSchedule] (
        [AssociateScheduleKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_AssociateSchedule] PRIMARY KEY ([AssociateScheduleKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[AssociateTimeRecurring] (
        [AssociateTimeRecurringKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_AssociateTimeRecurring] PRIMARY KEY ([AssociateTimeRecurringKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[LocationTimeRecurring] (
        [LocationTimeRecurringKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_LocationTimeRecurring] PRIMARY KEY ([LocationTimeRecurringKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ResourceSchedule] (
        [ResourceScheduleKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_ResourceSchedule] PRIMARY KEY ([ResourceScheduleKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ResourceTimeRecurring] (
        [ResourceTimeRecurringKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_ResourceTimeRecurring] PRIMARY KEY ([ResourceTimeRecurringKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[Schedule] (
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleName] nvarchar(50) NOT NULL,
        [ScheduleDescription] nvarchar(2000) NULL,
        CONSTRAINT [PK_Schedule] PRIMARY KEY ([ScheduleKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ScheduleSlot] (
        [ScheduleSlotKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ScheduleSlot] PRIMARY KEY ([ScheduleSlotKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ScheduleType] (
        [ScheduleTypeKey] uniqueidentifier NOT NULL,
        [ScheduleTypeName] nvarchar(50) NOT NULL,
        [ScheduleTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_ScheduleType] PRIMARY KEY ([ScheduleTypeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[Slot] (
        [SlotKey] uniqueidentifier NOT NULL,
        [SlotName] nvarchar(50) NOT NULL,
        [SlotDescription] nvarchar(2000) NULL,
        CONSTRAINT [PK_Slot] PRIMARY KEY ([SlotKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotLocation] (
        [SlotLocationKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotLocation] PRIMARY KEY ([SlotLocationKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotResource] (
        [SlotResourceKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [ResourceTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotResource] PRIMARY KEY ([SlotResourceKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotTimeRange] (
        [SlotTimeRangeKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [TimeRangeKey] uniqueidentifier NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotTimeRange] PRIMARY KEY ([SlotTimeRangeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotTimeRecurring] (
        [SlotTimeRecurringKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotTimeRecurring] PRIMARY KEY ([SlotTimeRecurringKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeCycle] (
        [TimeCycleKey] uniqueidentifier NOT NULL,
        [TimeCycleName] nvarchar(50) NOT NULL,
        [TimeCycleDescription] nvarchar(250) NULL,
        [Days] int NOT NULL,
        [Interval] int NOT NULL,
        CONSTRAINT [PK_TimeCycle] PRIMARY KEY ([TimeCycleKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeRange] (
        [TimeRangeKey] uniqueidentifier NOT NULL,
        [BeginDate] datetime NOT NULL,
        [EndDate] datetime NOT NULL,
        CONSTRAINT [PK_TimeRange] PRIMARY KEY ([TimeRangeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeRecurring] (
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [BeginDay] int NOT NULL,
        [EndDay] int NOT NULL,
        [BeginTime] datetime NOT NULL,
        [EndTime] datetime NOT NULL,
        [Interval] int NOT NULL,
        [TimeCycleKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_TimeRecurring] PRIMARY KEY ([TimeRecurringKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeType] (
        [TimeTypeKey] uniqueidentifier NOT NULL,
        [TimeTypeName] nvarchar(50) NOT NULL,
        [TimeTypeDescription] nvarchar(250) NULL,
        [TimeBehavior] int NOT NULL,
        CONSTRAINT [PK_TimeType] PRIMARY KEY ([TimeTypeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[VentureSchedule] (
        [VentureScheduleKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_VentureSchedule] PRIMARY KEY ([VentureScheduleKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[VentureTimeRecurring] (
        [VentureTimeRecurringKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_VentureTimeRecurring] PRIMARY KEY ([VentureTimeRecurringKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateSchedule_Key] ON [Chronology].[AssociateSchedule] ([AssociateScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateSchedule_All] ON [Chronology].[AssociateSchedule] ([AssociateKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateTimeRecurring_Key] ON [Chronology].[AssociateTimeRecurring] ([AssociateTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateTimeRecurring_All] ON [Chronology].[AssociateTimeRecurring] ([AssociateKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationTimeRecurring_Location] ON [Chronology].[LocationTimeRecurring] ([LocationTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationTimeRecurring_All] ON [Chronology].[LocationTimeRecurring] ([LocationKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceSchedule_Key] ON [Chronology].[ResourceSchedule] ([ResourceScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceSchedule_All] ON [Chronology].[ResourceSchedule] ([ResourceKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceTimeRecurring_Resource] ON [Chronology].[ResourceTimeRecurring] ([ResourceTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceTimeRecurring_All] ON [Chronology].[ResourceTimeRecurring] ([ResourceKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Schedule_ScheduleKey] ON [Chronology].[Schedule] ([ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE INDEX [IX_ScheduleSlot_Schedule] ON [Chronology].[ScheduleSlot] ([ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ScheduleSlot_Key] ON [Chronology].[ScheduleSlot] ([ScheduleSlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE INDEX [IX_ScheduleSlot_Slot] ON [Chronology].[ScheduleSlot] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ScheduleSlot_All] ON [Chronology].[ScheduleSlot] ([SlotKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ScheduleType_Key] ON [Chronology].[ScheduleType] ([ScheduleTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Slot_SlotKey] ON [Chronology].[Slot] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotLocation_Slot] ON [Chronology].[SlotLocation] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotLocation_Key] ON [Chronology].[SlotLocation] ([SlotLocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotLocation_All] ON [Chronology].[SlotLocation] ([SlotKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotResource_Resource] ON [Chronology].[SlotResource] ([ResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotResource_Slot] ON [Chronology].[SlotResource] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotResource_SlotResourceKey] ON [Chronology].[SlotResource] ([SlotResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotResource_All] ON [Chronology].[SlotResource] ([ResourceKey], [SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotTimeRange_Slot] ON [Chronology].[SlotTimeRange] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotTime_All] ON [Chronology].[SlotTimeRange] ([SlotKey], [TimeRangeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotTimeRecurring_Slot] ON [Chronology].[SlotTimeRecurring] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotTime_All] ON [Chronology].[SlotTimeRecurring] ([SlotKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeCycle_Key] ON [Chronology].[TimeCycle] ([TimeCycleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRange_TimeRangeKey] ON [Chronology].[TimeRange] ([TimeRangeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRange_All] ON [Chronology].[TimeRange] ([BeginDate], [EndDate]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRecurring_TimeRecurringKey] ON [Chronology].[TimeRecurring] ([TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRecurring_All] ON [Chronology].[TimeRecurring] ([BeginDay], [EndDay], [BeginTime], [EndTime], [Interval], [TimeCycleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeType_Key] ON [Chronology].[TimeType] ([TimeTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureSchedule_Key] ON [Chronology].[VentureSchedule] ([VentureScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureSchedule_All] ON [Chronology].[VentureSchedule] ([VentureKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureTimeRecurring_Venture] ON [Chronology].[VentureTimeRecurring] ([VentureTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureTimeRecurring_All] ON [Chronology].[VentureTimeRecurring] ([VentureKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043111_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200821043111_InitialCreate', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000927_20200821-170920')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200822000927_20200821-170920', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[VentureTimeRecurring] DROP CONSTRAINT [PK_VentureTimeRecurring];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[VentureSchedule] DROP CONSTRAINT [PK_VentureSchedule];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeType] DROP CONSTRAINT [PK_TimeType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeRecurring] DROP CONSTRAINT [PK_TimeRecurring];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeRange] DROP CONSTRAINT [PK_TimeRange];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeCycle] DROP CONSTRAINT [PK_TimeCycle];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotTimeRecurring] DROP CONSTRAINT [PK_SlotTimeRecurring];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotTimeRange] DROP CONSTRAINT [PK_SlotTimeRange];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotResource] DROP CONSTRAINT [PK_SlotResource];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotLocation] DROP CONSTRAINT [PK_SlotLocation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[Slot] DROP CONSTRAINT [PK_Slot];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ScheduleType] DROP CONSTRAINT [PK_ScheduleType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ScheduleSlot] DROP CONSTRAINT [PK_ScheduleSlot];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[Schedule] DROP CONSTRAINT [PK_Schedule];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ResourceTimeRecurring] DROP CONSTRAINT [PK_ResourceTimeRecurring];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ResourceSchedule] DROP CONSTRAINT [PK_ResourceSchedule];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[LocationTimeRecurring] DROP CONSTRAINT [PK_LocationTimeRecurring];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[AssociateTimeRecurring] DROP CONSTRAINT [PK_AssociateTimeRecurring];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[AssociateSchedule] DROP CONSTRAINT [PK_AssociateSchedule];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[VentureTimeRecurring] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[VentureSchedule] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeType] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeRecurring] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeRange] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeCycle] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotTimeRecurring] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotTimeRange] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotResource] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotLocation] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[Slot] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ScheduleType] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ScheduleSlot] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[Schedule] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ResourceTimeRecurring] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ResourceSchedule] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[LocationTimeRecurring] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[AssociateTimeRecurring] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[AssociateSchedule] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[VentureTimeRecurring] ADD CONSTRAINT [PK_VentureTimeRecurring] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[VentureSchedule] ADD CONSTRAINT [PK_VentureSchedule] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeType] ADD CONSTRAINT [PK_TimeType] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeRecurring] ADD CONSTRAINT [PK_TimeRecurring] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeRange] ADD CONSTRAINT [PK_TimeRange] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[TimeCycle] ADD CONSTRAINT [PK_TimeCycle] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotTimeRecurring] ADD CONSTRAINT [PK_SlotTimeRecurring] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotTimeRange] ADD CONSTRAINT [PK_SlotTimeRange] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotResource] ADD CONSTRAINT [PK_SlotResource] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[SlotLocation] ADD CONSTRAINT [PK_SlotLocation] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[Slot] ADD CONSTRAINT [PK_Slot] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ScheduleType] ADD CONSTRAINT [PK_ScheduleType] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ScheduleSlot] ADD CONSTRAINT [PK_ScheduleSlot] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[Schedule] ADD CONSTRAINT [PK_Schedule] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ResourceTimeRecurring] ADD CONSTRAINT [PK_ResourceTimeRecurring] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[ResourceSchedule] ADD CONSTRAINT [PK_ResourceSchedule] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[LocationTimeRecurring] ADD CONSTRAINT [PK_LocationTimeRecurring] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[AssociateTimeRecurring] ADD CONSTRAINT [PK_AssociateTimeRecurring] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    ALTER TABLE [Chronology].[AssociateSchedule] ADD CONSTRAINT [PK_AssociateSchedule] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904190307_20200904-120238')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200904190307_20200904-120238', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233551_20200904-163527')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200904233551_20200904-163527', N'3.1.7');
END;

GO

