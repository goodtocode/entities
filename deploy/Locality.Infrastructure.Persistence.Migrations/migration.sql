IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Locality') IS NULL EXEC(N'CREATE SCHEMA [Locality];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[AssociateLocation] (
        [AssociateLocationKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_AssociateLocation] PRIMARY KEY ([AssociateLocationKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[Coordinate] (
        [CoordinateKey] uniqueidentifier NOT NULL,
        [CoordinatePoint] geography NULL,
        CONSTRAINT [PK_Coordinate] PRIMARY KEY ([CoordinateKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[GeoArea] (
        [GeoAreaKey] uniqueidentifier NOT NULL,
        [GeodeticArea] geometry NULL,
        CONSTRAINT [PK_GeoArea] PRIMARY KEY ([GeoAreaKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[GeoDistance] (
        [GeoDistanceKey] uniqueidentifier NOT NULL,
        [StartLatLongKey] uniqueidentifier NOT NULL,
        [EndLatLongKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_GeoDistance] PRIMARY KEY ([GeoDistanceKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[GeoLocation] (
        [GeoLocationKey] uniqueidentifier NOT NULL,
        [LatLongKey] uniqueidentifier NOT NULL,
        [Elevation] geography NULL,
        CONSTRAINT [PK_GeoLocation] PRIMARY KEY ([GeoLocationKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[LatLong] (
        [LatLongKey] uniqueidentifier NOT NULL,
        [Latitude] float NOT NULL,
        [Longitude] float NOT NULL,
        CONSTRAINT [PK_LatLong] PRIMARY KEY ([LatLongKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[Line] (
        [LineKey] uniqueidentifier NOT NULL,
        [StartPoint] geography NULL,
        [EndPoint] geography NULL,
        CONSTRAINT [PK_Line] PRIMARY KEY ([LineKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[Location] (
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationName] nvarchar(50) NOT NULL,
        [LocationDescription] nvarchar(2000) NULL,
        CONSTRAINT [PK_Location] PRIMARY KEY ([LocationKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[LocationArea] (
        [LocationAreaKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [PolygonKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_LocationArea] PRIMARY KEY ([LocationAreaKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[LocationType] (
        [LocationTypeKey] uniqueidentifier NOT NULL,
        [LocationTypeName] nvarchar(50) NOT NULL,
        [LocationTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_LocationType] PRIMARY KEY ([LocationTypeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[Polygon] (
        [PolygonKey] uniqueidentifier NOT NULL,
        [PolygonSequence] geometry NULL,
        CONSTRAINT [PK_Polygon] PRIMARY KEY ([PolygonKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[ResourceLocation] (
        [ResourceLocationKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_ResourceLocation] PRIMARY KEY ([ResourceLocationKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE TABLE [Locality].[VentureLocation] (
        [VentureLocationKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [LocationKey] uniqueidentifier NOT NULL,
        [LocationTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_VentureLocation] PRIMARY KEY ([VentureLocationKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateLocation_All] ON [Locality].[AssociateLocation] ([AssociateKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Coordinate_Key] ON [Locality].[Coordinate] ([CoordinateKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_GeoArea_Key] ON [Locality].[GeoArea] ([GeoAreaKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_GeoDistance_Key] ON [Locality].[GeoDistance] ([GeoDistanceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_GeoLocation_Key] ON [Locality].[GeoLocation] ([GeoLocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LatLong_Key] ON [Locality].[LatLong] ([LatLongKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Line_Key] ON [Locality].[Line] ([LineKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Location_LocationKey] ON [Locality].[Location] ([LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationArea_Key] ON [Locality].[LocationArea] ([LocationAreaKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE INDEX [IX_LocationArea_LocationId] ON [Locality].[LocationArea] ([LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationArea_All] ON [Locality].[LocationArea] ([LocationKey], [PolygonKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_LocationType_Key] ON [Locality].[LocationType] ([LocationTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Polygon_Key] ON [Locality].[Polygon] ([PolygonKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceLocation_All] ON [Locality].[ResourceLocation] ([ResourceKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureLocation_Key] ON [Locality].[VentureLocation] ([VentureLocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureLocation_All] ON [Locality].[VentureLocation] ([VentureKey], [LocationKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822000814_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200822000814_InitialCreate', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    DROP TABLE [Locality].[Coordinate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    DROP TABLE [Locality].[GeoArea];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    DROP TABLE [Locality].[GeoLocation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    DROP TABLE [Locality].[Line];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    DROP TABLE [Locality].[Polygon];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[VentureLocation] DROP CONSTRAINT [PK_VentureLocation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[ResourceLocation] DROP CONSTRAINT [PK_ResourceLocation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LocationType] DROP CONSTRAINT [PK_LocationType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LocationArea] DROP CONSTRAINT [PK_LocationArea];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[Location] DROP CONSTRAINT [PK_Location];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LatLong] DROP CONSTRAINT [PK_LatLong];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[GeoDistance] DROP CONSTRAINT [PK_GeoDistance];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[AssociateLocation] DROP CONSTRAINT [PK_AssociateLocation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[VentureLocation] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[ResourceLocation] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LocationType] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LocationArea] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[Location] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LatLong] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[GeoDistance] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[AssociateLocation] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[VentureLocation] ADD CONSTRAINT [PK_VentureLocation] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[ResourceLocation] ADD CONSTRAINT [PK_ResourceLocation] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LocationType] ADD CONSTRAINT [PK_LocationType] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LocationArea] ADD CONSTRAINT [PK_LocationArea] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[Location] ADD CONSTRAINT [PK_Location] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[LatLong] ADD CONSTRAINT [PK_LatLong] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[GeoDistance] ADD CONSTRAINT [PK_GeoDistance] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    ALTER TABLE [Locality].[AssociateLocation] ADD CONSTRAINT [PK_AssociateLocation] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233451_20200904-163427')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200904233451_20200904-163427', N'3.1.7');
END;

GO

