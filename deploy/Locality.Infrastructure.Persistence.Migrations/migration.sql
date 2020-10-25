IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    IF SCHEMA_ID(N'Locality') IS NULL EXEC(N'CREATE SCHEMA [Locality];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[AssociateLocation] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [AssociateLocationKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_AssociateLocation] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[GeoDistance] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [GeoDistanceKey] uniqueidentifier NOT NULL,
        [StartLatLongKey] uniqueidentifier NOT NULL,
        [EndLatLongKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_GeoDistance] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[LatLong] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [LatLongKey] uniqueidentifier NOT NULL,
        [Latitude] float NOT NULL,
        [Longitude] float NOT NULL,
        CONSTRAINT [PK_LatLong] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[Location] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationName] nvarchar(50) NOT NULL,
        [LocationDescription] nvarchar(2000) NULL,
        CONSTRAINT [PK_Location] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[LocationArea] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [LocationAreaKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [PolygonKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_LocationArea] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[LocationType] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [LocationTypeKey] uniqueidentifier NOT NULL,
        [LocationTypeName] nvarchar(50) NOT NULL,
        [LocationTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_LocationType] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[ResourceLocation] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [ResourceLocationKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_ResourceLocation] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE TABLE [Locality].[VentureLocation] (
        [RowKey] uniqueidentifier NOT NULL,
        [PartitionKey] nvarchar(max) NULL,
        [VentureLocationKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_VentureLocation] PRIMARY KEY ([RowKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateLocation_All] ON [Locality].[AssociateLocation] ([AssociateKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_GeoDistance_Key] ON [Locality].[GeoDistance] ([GeoDistanceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_LatLong_Key] ON [Locality].[LatLong] ([LatLongKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_Location_LocationKey] ON [Locality].[Location] ([LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationArea_Key] ON [Locality].[LocationArea] ([LocationAreaKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE INDEX [IX_LocationArea_LocationId] ON [Locality].[LocationArea] ([LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationArea_All] ON [Locality].[LocationArea] ([LocationKey], [PolygonKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationType_Key] ON [Locality].[LocationType] ([LocationTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceLocation_All] ON [Locality].[ResourceLocation] ([ResourceKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureLocation_Key] ON [Locality].[VentureLocation] ([VentureLocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureLocation_All] ON [Locality].[VentureLocation] ([VentureKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200920045928_20200919-215906')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200920045928_20200919-215906', N'3.1.9');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201025024420_20201024-194355')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201025024420_20201024-194355', N'3.1.9');
END;

GO

