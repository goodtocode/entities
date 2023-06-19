﻿----------------------------------------------------------------
---- Setting 
----------------------------------------------------------------
---- Settings

--MERGE INTO [Setting].[Setting] AS Target 
--USING (VALUES ()
--	)
--AS Source ([SettingKey], [SettingTypeKey], [SettingName], [SettingValue])
--ON Target.[SettingKey] = Source.[SettingKey]
---- Update
--WHEN MATCHED THEN 
--	UPDATE SET [SettingTypeKey] = Source.[SettingTypeKey] , [SettingName] = Source.[SettingName], [SettingValue] = Source.[SettingValue]
---- Insert 
--WHEN NOT MATCHED BY TARGET THEN 
--	INSERT ([SettingKey], [SettingTypeKey], [SettingName], [SettingValue]) 
--		Values (Source.[SettingKey], Source.[SettingTypeKey], Source.[SettingName], Source.[SettingValue])
--; -- No delete, terminate
