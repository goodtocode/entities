CREATE TABLE [Setting].[ModuleSetting] (
    [ModuleSettingId] INT IDENTITY(1,1) CONSTRAINT [DF_ModuleSetting_Id] NOT NULL,
    [ModuleSettingKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_ModuleSetting_Key] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [SettingKey]       UNIQUEIDENTIFIER CONSTRAINT [DF_ModuleSetting_Setting] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ModuleKey]        UNIQUEIDENTIFIER CONSTRAINT [DF_ModuleSetting_Module] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]     DATETIME         CONSTRAINT [DF_ModuleSetting_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_ModuleSetting] PRIMARY KEY CLUSTERED ([ModuleSettingId] ASC),
    CONSTRAINT [FK_ModuleSetting_Setting] FOREIGN KEY ([SettingKey]) REFERENCES [Setting].[Setting] ([SettingKey]),
    CONSTRAINT [FK_ModuleSetting_Module] FOREIGN KEY ([ModuleKey]) REFERENCES [Entity].[Module] ([ModuleKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ModuleSetting_Key] ON [Setting].[ModuleSetting] ([ModuleSettingKey] Asc)
GO