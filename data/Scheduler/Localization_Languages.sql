--
--Language
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].[Localization].[Language]
Order By CreatedDate
SELECT [LanguageID],[LanguageName],[LanguageDescription],[NativeName],[Locale],[SortOrder],[ISO693-1],[CreatedDate],[ModifiedDate],[ClusterID]
  FROM [EntityData].[Localization].[Language]
--
--Text
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].[Localization].[TextTable]
Order By CreatedDate