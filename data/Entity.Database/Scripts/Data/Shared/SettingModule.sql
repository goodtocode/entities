﻿--------------------------------------------------------------
-- SettingModule
--------------------------------------------------------------
--
-- SettingsModule
--
--MERGE INTO [Setting].[SettingModule] AS Target 
--USING (VALUES (
--	)
--AS Source([SettingModuleKey], [SettingKey], [ModuleKey])
--ON Target.[SettingModuleKey] = Source.[SettingModuleKey]
---- Update
--WHEN MATCHED THEN 
--	UPDATE SET [SettingKey] = Source.[SettingKey], [ModuleKey] = Source.[ModuleKey]
---- Insert 
--WHEN NOT MATCHED BY TARGET THEN 
--	INSERT ([SettingModuleKey], [SettingKey], [ModuleKey]) 
--		Values (Source.[SettingModuleKey], Source.[SettingKey], Source.[ModuleKey])
--; -- No delete, terminate

