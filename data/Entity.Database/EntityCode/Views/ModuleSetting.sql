Create VIEW [EntityCode].[ModuleSetting]
	AS 
SELECT	MSet.ModuleSettingId As [Id],		
		MSet.ModuleSettingKey As [Key],
        MSet.ModuleKey,
		MSet.SettingKey,
        S.SettingName,
		S.SettingTypeKey,
		S.SettingValue,
		S.CreatedDate,
		S.ModifiedDate
From	[Setting].[ModuleSetting] MSet
Join	[Setting].[Setting] S On MSet.SettingKey = S.SettingKey

		

		