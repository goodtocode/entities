Create VIEW [EntityCode].[ApplicationSetting]
	AS
SELECT	ASet.ApplicationSettingId As [Id],
        ASet.ApplicationSettingKey As [Key],
		Aset.ApplicationKey,
		Aset.SettingKey,
		S.SettingTypeKey,
        S.SettingName,
		S.SettingValue,
		S.CreatedDate,
		S.ModifiedDate
From	[Setting].[ApplicationSetting] ASet
Join	[Setting].[Setting] S On ASet.SettingKey = S.SettingKey
