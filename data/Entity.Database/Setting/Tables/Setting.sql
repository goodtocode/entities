CREATE TABLE [Setting].[Setting] (
    [SettingId]     INT IDENTITY(1, 1) CONSTRAINT [DF_Setting_Id] NOT NULL,
	[SettingKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_Setting_Key] DEFAULT(NewId()) NOT NULL,
    [SettingTypeKey] INT CONSTRAINT [DF_Setting_SettingTypeKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [SettingName]   NVARCHAR (50)    CONSTRAINT [DF_Setting_SettingName] DEFAULT ('') NOT NULL,
    [SettingValue]  NVARCHAR (200)   CONSTRAINT [DF_Setting_SettingValue] DEFAULT ('') NOT NULL,
    [CreatedDate]   DATETIME         CONSTRAINT [DF_Setting_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]  DATETIME         CONSTRAINT [DF_Setting_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([SettingId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Setting_Key] ON [Setting].[Setting] ([SettingKey] Asc)
GO
