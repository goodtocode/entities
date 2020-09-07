﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    IF SCHEMA_ID(N'Subjects') IS NULL EXEC(N'CREATE SCHEMA [Subjects];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Associate] (
        [AssociateKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Associate] PRIMARY KEY ([AssociateKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[AssociateDetail] (
        [AssociateDetailKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [DetailKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AssociateDetail] PRIMARY KEY ([AssociateDetailKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[AssociateOption] (
        [AssociateOptionKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        [OptionKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AssociateOption] PRIMARY KEY ([AssociateOptionKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Business] (
        [BusinessKey] uniqueidentifier NOT NULL,
        [BusinessName] nvarchar(50) NOT NULL,
        [TaxNumber] nvarchar(20) NULL,
        CONSTRAINT [PK_Business] PRIMARY KEY ([BusinessKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Detail] (
        [DetailKey] uniqueidentifier NOT NULL,
        [DetailTypeKey] uniqueidentifier NOT NULL,
        [DetailData] nvarchar(2000) NOT NULL,
        CONSTRAINT [PK_Detail] PRIMARY KEY ([DetailKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[DetailType] (
        [DetailTypeKey] uniqueidentifier NOT NULL,
        [DetailTypeName] nvarchar(50) NOT NULL,
        [DetailTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_DetailType] PRIMARY KEY ([DetailTypeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Gender] (
        [GenderKey] uniqueidentifier NOT NULL,
        [GenderName] nvarchar(50) NOT NULL,
        [GenderCode] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_Gender] PRIMARY KEY ([GenderKey]),
        CONSTRAINT [CC_Gender_GenderCode] CHECK (GenderCode in ('M', 'F', 'N/A', 'U/K'))
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Government] (
        [GovernmentKey] uniqueidentifier NOT NULL,
        [GovernmentName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Government] PRIMARY KEY ([GovernmentKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Item] (
        [ItemKey] uniqueidentifier NOT NULL,
        [ItemName] nvarchar(50) NOT NULL,
        [ItemDescription] nvarchar(2000) NOT NULL,
        [ItemTypeKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Item] PRIMARY KEY ([ItemKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[ItemGroup] (
        [ItemGroupKey] uniqueidentifier NOT NULL,
        [ItemGroupName] nvarchar(50) NOT NULL,
        [ItemGroupDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_ItemGroup] PRIMARY KEY ([ItemGroupKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[ItemType] (
        [ItemTypeKey] uniqueidentifier NOT NULL,
        [ItemGroupKey] uniqueidentifier NOT NULL,
        [ItemTypeName] nvarchar(50) NOT NULL,
        [ItemTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_ItemType] PRIMARY KEY ([ItemTypeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Option] (
        [OptionKey] uniqueidentifier NOT NULL,
        [OptionGroupKey] uniqueidentifier NOT NULL,
        [OptionName] nvarchar(50) NOT NULL,
        [OptionDescription] nvarchar(250) NULL,
        [OptionCode] nvarchar(10) NOT NULL,
        [SortOrder] int NOT NULL,
        CONSTRAINT [PK_Option] PRIMARY KEY ([OptionKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[OptionGroup] (
        [OptionGroupKey] uniqueidentifier NOT NULL,
        [OptionGroupName] nvarchar(50) NOT NULL,
        [OptionGroupDescription] nvarchar(250) NULL,
        [OptionGroupCode] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_OptionGroup] PRIMARY KEY ([OptionGroupKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Person] (
        [PersonKey] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(50) NOT NULL,
        [MiddleName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [BirthDate] datetime NOT NULL,
        [GenderCode] nvarchar(3) NULL,
        CONSTRAINT [PK_Person] PRIMARY KEY ([PersonKey]),
        CONSTRAINT [CC_Person_GenderCode] CHECK (GenderCode in ('M', 'F', 'N/A', 'U/K'))
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Resource] (
        [ResourceKey] uniqueidentifier NOT NULL,
        [ResourceName] nvarchar(50) NOT NULL,
        [ResourceDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_Resource] PRIMARY KEY ([ResourceKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[ResourceItem] (
        [ResourceItemKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [ItemKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ResourceItem] PRIMARY KEY ([ResourceItemKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[ResourcePerson] (
        [ResourcePersonKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [PersonKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ResourcePerson] PRIMARY KEY ([ResourcePersonKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[ResourceType] (
        [ResourceTypeKey] uniqueidentifier NOT NULL,
        [ResourceTypeName] nvarchar(50) NOT NULL,
        [ResourceTypeDescription] nvarchar(250) NULL,
        CONSTRAINT [PK_ResourceType] PRIMARY KEY ([ResourceTypeKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[Venture] (
        [VentureKey] uniqueidentifier NOT NULL,
        [VentureGroupKey] uniqueidentifier NULL,
        [VentureTypeKey] uniqueidentifier NULL,
        [VentureName] nvarchar(50) NOT NULL,
        [VentureDescription] nvarchar(250) NULL,
        [VentureSlogan] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Venture] PRIMARY KEY ([VentureKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[VentureAssociateOption] (
        [VentureAssociateOptionKey] uniqueidentifier NOT NULL,
        [OptionKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [AssociateKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_VentureAssociateOption] PRIMARY KEY ([VentureAssociateOptionKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[VentureDetail] (
        [VentureDetailKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [DetailKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_VentureDetail] PRIMARY KEY ([VentureDetailKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[VentureOption] (
        [VentureOptionKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [OptionKey] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_VentureOption] PRIMARY KEY ([VentureOptionKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE TABLE [Subjects].[VentureResource] (
        [VentureResourceKey] uniqueidentifier NOT NULL,
        [VentureKey] uniqueidentifier NOT NULL,
        [ResourceKey] uniqueidentifier NOT NULL,
        [ResourceTypeKey] uniqueidentifier NULL,
        CONSTRAINT [PK_VentureResource] PRIMARY KEY ([VentureResourceKey])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateLocation_Associate] ON [Subjects].[Associate] ([AssociateKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateDetail_Key] ON [Subjects].[AssociateDetail] ([AssociateDetailKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateDetail_All] ON [Subjects].[AssociateDetail] ([AssociateKey], [AssociateDetailKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_AssociateOption_All] ON [Subjects].[AssociateOption] ([AssociateKey], [OptionKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Business_Key] ON [Subjects].[Business] ([BusinessKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Detail_Key] ON [Subjects].[Detail] ([DetailKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_DetailType_Key] ON [Subjects].[DetailType] ([DetailTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Gender_Code] ON [Subjects].[Gender] ([GenderCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Gender_Key] ON [Subjects].[Gender] ([GenderKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Government_Associate] ON [Subjects].[Government] ([GovernmentKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Item_ItemKey] ON [Subjects].[Item] ([ItemKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_ItemGroup_Key] ON [Subjects].[ItemGroup] ([ItemGroupKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_ItemType_Key] ON [Subjects].[ItemType] ([ItemTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Option_OptionKey] ON [Subjects].[Option] ([OptionKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Option_OptionCode] ON [Subjects].[Option] ([OptionGroupKey], [OptionCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Option_OptionGroupCode] ON [Subjects].[OptionGroup] ([OptionGroupCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Option_OptionGroupKey] ON [Subjects].[OptionGroup] ([OptionGroupKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Person_Associate] ON [Subjects].[Person] ([PersonKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE INDEX [IX_Person_All] ON [Subjects].[Person] ([FirstName], [MiddleName], [LastName], [BirthDate]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Resource_ResourceKey] ON [Subjects].[Resource] ([ResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE INDEX [IX_ResourceItem_Item] ON [Subjects].[ResourceItem] ([ItemKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceItem_Key] ON [Subjects].[ResourceItem] ([ResourceItemKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE INDEX [IX_ResourceItem_Resource] ON [Subjects].[ResourceItem] ([ResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceItem_All] ON [Subjects].[ResourceItem] ([ResourceKey], [ItemKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE INDEX [IX_ResourcePerson_Person] ON [Subjects].[ResourcePerson] ([PersonKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE INDEX [IX_ResourcePerson_Resource] ON [Subjects].[ResourcePerson] ([ResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourcePerson_Key] ON [Subjects].[ResourcePerson] ([ResourcePersonKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourcePerson_All] ON [Subjects].[ResourcePerson] ([ResourceKey], [PersonKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_ResourceType_Key] ON [Subjects].[ResourceType] ([ResourceTypeKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_Venture_VentureKey] ON [Subjects].[Venture] ([VentureKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureAssociateOption_Key] ON [Subjects].[VentureAssociateOption] ([VentureAssociateOptionKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureDetail_Key] ON [Subjects].[VentureDetail] ([VentureDetailKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureDetail_All] ON [Subjects].[VentureDetail] ([VentureKey], [VentureDetailKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureOption_All] ON [Subjects].[VentureOption] ([VentureKey], [OptionKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureResource_Key] ON [Subjects].[VentureResource] ([VentureResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    CREATE UNIQUE INDEX [IX_VentureResource_All] ON [Subjects].[VentureResource] ([VentureKey], [ResourceKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821043644_20200820-213636')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200821043644_20200820-213636', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822001042_20200821-171035')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200822001042_20200821-171035', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureResource] DROP CONSTRAINT [PK_VentureResource];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureOption] DROP CONSTRAINT [PK_VentureOption];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureDetail] DROP CONSTRAINT [PK_VentureDetail];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureAssociateOption] DROP CONSTRAINT [PK_VentureAssociateOption];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Venture] DROP CONSTRAINT [PK_Venture];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourceType] DROP CONSTRAINT [PK_ResourceType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourcePerson] DROP CONSTRAINT [PK_ResourcePerson];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourceItem] DROP CONSTRAINT [PK_ResourceItem];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Resource] DROP CONSTRAINT [PK_Resource];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Person] DROP CONSTRAINT [PK_Person];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[OptionGroup] DROP CONSTRAINT [PK_OptionGroup];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Option] DROP CONSTRAINT [PK_Option];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ItemType] DROP CONSTRAINT [PK_ItemType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ItemGroup] DROP CONSTRAINT [PK_ItemGroup];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Item] DROP CONSTRAINT [PK_Item];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Government] DROP CONSTRAINT [PK_Government];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Gender] DROP CONSTRAINT [PK_Gender];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[DetailType] DROP CONSTRAINT [PK_DetailType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Detail] DROP CONSTRAINT [PK_Detail];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Business] DROP CONSTRAINT [PK_Business];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[AssociateOption] DROP CONSTRAINT [PK_AssociateOption];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[AssociateDetail] DROP CONSTRAINT [PK_AssociateDetail];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Associate] DROP CONSTRAINT [PK_Associate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureResource] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureOption] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureDetail] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureAssociateOption] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Venture] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourceType] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourcePerson] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourceItem] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Resource] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Person] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[OptionGroup] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Option] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ItemType] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ItemGroup] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Item] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Government] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Gender] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[DetailType] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Detail] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Business] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[AssociateOption] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[AssociateDetail] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Associate] ADD [RowKey] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureResource] ADD CONSTRAINT [PK_VentureResource] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureOption] ADD CONSTRAINT [PK_VentureOption] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureDetail] ADD CONSTRAINT [PK_VentureDetail] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[VentureAssociateOption] ADD CONSTRAINT [PK_VentureAssociateOption] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Venture] ADD CONSTRAINT [PK_Venture] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourceType] ADD CONSTRAINT [PK_ResourceType] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourcePerson] ADD CONSTRAINT [PK_ResourcePerson] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ResourceItem] ADD CONSTRAINT [PK_ResourceItem] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Resource] ADD CONSTRAINT [PK_Resource] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Person] ADD CONSTRAINT [PK_Person] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[OptionGroup] ADD CONSTRAINT [PK_OptionGroup] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Option] ADD CONSTRAINT [PK_Option] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ItemType] ADD CONSTRAINT [PK_ItemType] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[ItemGroup] ADD CONSTRAINT [PK_ItemGroup] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Item] ADD CONSTRAINT [PK_Item] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Government] ADD CONSTRAINT [PK_Government] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Gender] ADD CONSTRAINT [PK_Gender] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[DetailType] ADD CONSTRAINT [PK_DetailType] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Detail] ADD CONSTRAINT [PK_Detail] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Business] ADD CONSTRAINT [PK_Business] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[AssociateOption] ADD CONSTRAINT [PK_AssociateOption] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[AssociateDetail] ADD CONSTRAINT [PK_AssociateDetail] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    ALTER TABLE [Subjects].[Associate] ADD CONSTRAINT [PK_Associate] PRIMARY KEY ([RowKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200904233242_20200904-163213')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200904233242_20200904-163213', N'3.1.7');
END;

GO
