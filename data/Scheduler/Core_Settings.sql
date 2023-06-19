--
-- Settings
--
-- Application
Select *
From	[EntityData].[Entity].Application A
Left Join	[EntityData].Setting.SettingApplication ASet On A.ApplicationID = ASet.ApplicationID
Left Join	[EntityData].Setting.Setting S On Aset.SettingID = S.SettingID

-- Module
Select *
From	[EntityData].[Entity].Module A
Left Join	[EntityData].Setting.SettingModule ASet On A.ModuleID = ASet.ModuleID
Left Join	[EntityData].Setting.Setting S On Aset.SettingID = S.SettingID
