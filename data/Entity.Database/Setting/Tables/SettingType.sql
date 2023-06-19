CREATE TABLE [Setting].[SettingType] (
    [SettingTypeId]   INT IDENTITY(1, 1) CONSTRAINT [DF_SettingType_SettingTypeId] NOT NULL,
	[SettingTypeKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_SettingType_SettingTypeKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [SettingTypeName] NVARCHAR (50)    CONSTRAINT [DF_SettingType_SettingTypeName] DEFAULT ('') NOT NULL,
    [CreatedDate]     DATETIME         CONSTRAINT [DF_SettingType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_SettingType] PRIMARY KEY CLUSTERED ([SettingTypeId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_SettingType_Key] ON [Setting].[SettingType] ([SettingTypeKey] Asc)
GO
