IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Chronology') IS NULL EXEC(N'CREATE SCHEMA [Chronology];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[AssociateSchedule] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [AssociateScheduleKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_AssociateSchedule] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[AssociateTimeRecurring] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [AssociateTimeRecurringKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_AssociateTimeRecurring] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[LocationTimeRecurring] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [LocationTimeRecurringKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_LocationTimeRecurring] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ResourceSchedule] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [ResourceScheduleKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_ResourceSchedule] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ResourceTimeRecurring] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [ResourceTimeRecurringKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_ResourceTimeRecurring] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[Schedule] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleName] nvarchar(50) NOT NULL,
        [ScheduleDescription] nvarchar(2000) NULL,
        CONSTRAINT [PK_Schedule] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ScheduleSlot] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [ScheduleSlotKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ScheduleSlot] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[ScheduleType] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [ScheduleTypeKey] uniqueidentifier NOT NULL,
        [ScheduleTypeName] nvarchar(50) NOT NULL,
        [ScheduleTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_ScheduleType] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[Slot] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [SlotName] nvarchar(50) NOT NULL,
        [SlotDescription] nvarchar(2000) NULL,
        CONSTRAINT [PK_Slot] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotLocation] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [SlotLocationKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotLocation] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotResource] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [SlotResourceKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [ResourceTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotResource] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotTimeRange] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [SlotTimeRangeKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [TimeRangeKey] uniqueidentifier NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotTimeRange] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[SlotTimeRecurring] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [SlotTimeRecurringKey] uniqueidentifier NOT NULL,
        [SlotKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_SlotTimeRecurring] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeCycle] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [TimeCycleKey] uniqueidentifier NOT NULL,
        [TimeCycleName] nvarchar(50) NOT NULL,
        [TimeCycleDescription] nvarchar(250) NULL,
        [Days] int NOT NULL,
        [Interval] int NOT NULL,
        CONSTRAINT [PK_TimeCycle] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeRange] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [TimeRangeKey] uniqueidentifier NOT NULL,
        [BeginDate] datetime NOT NULL,
        [EndDate] datetime NOT NULL,
        CONSTRAINT [PK_TimeRange] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeRecurring] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [BeginDay] int NOT NULL,
        [EndDay] int NOT NULL,
        [BeginTime] datetime NOT NULL,
        [EndTime] datetime NOT NULL,
        [Interval] int NOT NULL,
        [TimeCycleKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_TimeRecurring] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[TimeType] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [TimeTypeKey] uniqueidentifier NOT NULL,
        [TimeTypeName] nvarchar(50) NOT NULL,
        [TimeTypeDescription] nvarchar(250) NULL,
        [TimeBehavior] int NOT NULL,
        CONSTRAINT [PK_TimeType] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[VentureSchedule] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [VentureScheduleKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [ScheduleKey] uniqueidentifier NOT NULL,
        [ScheduleTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_VentureSchedule] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE TABLE [Chronology].[VentureTimeRecurring] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [VentureTimeRecurringKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [TimeRecurringKey] uniqueidentifier NOT NULL,
        [DayName] nvarchar(50) NOT NULL,
        [TimeName] nvarchar(50) NOT NULL,
        [TimeTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_VentureTimeRecurring] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateSchedule_Key] ON [Chronology].[AssociateSchedule] ([AssociateScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateSchedule_All] ON [Chronology].[AssociateSchedule] ([AssociateKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateTimeRecurring_Key] ON [Chronology].[AssociateTimeRecurring] ([AssociateTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateTimeRecurring_All] ON [Chronology].[AssociateTimeRecurring] ([AssociateKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationTimeRecurring_Location] ON [Chronology].[LocationTimeRecurring] ([LocationTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationTimeRecurring_All] ON [Chronology].[LocationTimeRecurring] ([LocationKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceSchedule_Key] ON [Chronology].[ResourceSchedule] ([ResourceScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceSchedule_All] ON [Chronology].[ResourceSchedule] ([ResourceKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceTimeRecurring_Resource] ON [Chronology].[ResourceTimeRecurring] ([ResourceTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceTimeRecurring_All] ON [Chronology].[ResourceTimeRecurring] ([ResourceKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Schedule_ScheduleKey] ON [Chronology].[Schedule] ([ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE INDEX [IX_ScheduleSlot_Schedule] ON [Chronology].[ScheduleSlot] ([ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ScheduleSlot_Key] ON [Chronology].[ScheduleSlot] ([ScheduleSlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE INDEX [IX_ScheduleSlot_Slot] ON [Chronology].[ScheduleSlot] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ScheduleSlot_All] ON [Chronology].[ScheduleSlot] ([SlotKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ScheduleType_Key] ON [Chronology].[ScheduleType] ([ScheduleTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Slot_SlotKey] ON [Chronology].[Slot] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotLocation_Slot] ON [Chronology].[SlotLocation] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotLocation_Key] ON [Chronology].[SlotLocation] ([SlotLocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotLocation_All] ON [Chronology].[SlotLocation] ([SlotKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotResource_Resource] ON [Chronology].[SlotResource] ([ResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotResource_Slot] ON [Chronology].[SlotResource] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotResource_SlotResourceKey] ON [Chronology].[SlotResource] ([SlotResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotResource_All] ON [Chronology].[SlotResource] ([ResourceKey], [SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotTimeRange_Slot] ON [Chronology].[SlotTimeRange] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotTime_All] ON [Chronology].[SlotTimeRange] ([SlotKey], [TimeRangeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE INDEX [IX_SlotTimeRecurring_Slot] ON [Chronology].[SlotTimeRecurring] ([SlotKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_SlotTime_All] ON [Chronology].[SlotTimeRecurring] ([SlotKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeCycle_Key] ON [Chronology].[TimeCycle] ([TimeCycleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRange_TimeRangeKey] ON [Chronology].[TimeRange] ([TimeRangeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRange_All] ON [Chronology].[TimeRange] ([BeginDate], [EndDate]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRecurring_TimeRecurringKey] ON [Chronology].[TimeRecurring] ([TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeRecurring_All] ON [Chronology].[TimeRecurring] ([BeginDay], [EndDay], [BeginTime], [EndTime], [Interval], [TimeCycleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeType_Key] ON [Chronology].[TimeType] ([TimeTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureSchedule_Key] ON [Chronology].[VentureSchedule] ([VentureScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureSchedule_All] ON [Chronology].[VentureSchedule] ([VentureKey], [ScheduleKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureTimeRecurring_Venture] ON [Chronology].[VentureTimeRecurring] ([VentureTimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureTimeRecurring_All] ON [Chronology].[VentureTimeRecurring] ([VentureKey], [TimeRecurringKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045611_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200920045611_InitialCreate', N'3.1.9');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201025024530_20201024-194504')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201025024530_20201024-194504', N'3.1.9');
END;

GO

