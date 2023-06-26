CREATE TABLE [Setting].[ApplicationSetting] (
    [ApplicationSettingId]  INT IDENTITY(1, 1) CONSTRAINT [DF_ApplicationSetting_ApplicationSettingId] NOT NULL,
    [ApplicationSettingKey] UNIQUEIDENTIFIER CONSTRAINT [DF_ApplicationSetting_Key] DEFAULT(NewId()) NOT NULL,
    [SettingKey]            UNIQUEIDENTIFIER CONSTRAINT [DF_ApplicationSetting_Setting] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ApplicationKey]        UNIQUEIDENTIFIER CONSTRAINT [DF_ApplicationSetting_Application] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,    
	[CreatedDate]           DATETIME         CONSTRAINT [DF_ApplicationSetting_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_ApplicationSetting] PRIMARY KEY CLUSTERED ([ApplicationSettingId] ASC),
    CONSTRAINT [FK_ApplicationSetting_Setting] FOREIGN KEY ([SettingKey]) REFERENCES [Setting].[Setting] ([SettingKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ApplicationSetting_Key] ON [Setting].[ApplicationSetting] ([ApplicationSettingKey] Asc)
GO
