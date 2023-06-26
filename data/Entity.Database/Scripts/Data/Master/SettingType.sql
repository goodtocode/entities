--------------------------------------------------------------
-- Setting - Global data to all products
--------------------------------------------------------------
-- SettingType
MERGE INTO [Setting].[SettingType] AS Target 
USING (VALUES (N'4eb25417-be3e-e411-9419-00155d016607', N'URLSimple')
	,(N'f2c317fe-be3e-e411-9419-00155d016607', N'URLFacebook')
	,(N'f5c317fe-be3e-e411-9419-00155d016607', N'WebTitle')
	,(N'f8c317fe-be3e-e411-9419-00155d016607', N'WebDescription')
	,(N'fbc317fe-be3e-e411-9419-00155d016607', N'WebKeywords')
	,(N'fec317fe-be3e-e411-9419-00155d016607', N'FacebookAppID')
	,(N'01c417fe-be3e-e411-9419-00155d016607', N'FacebookPageID')
	,(N'04c417fe-be3e-e411-9419-00155d016607', N'FacebookAdminID')
	,(N'76c152bb-97a2-4238-b36d-03b63407fd27', N'BingMapKey')
	,(N'6815f709-ef40-4d65-b674-169a26f1275a', N'SiteURLFull')
	,(N'19d5bf05-605a-4dde-9f7d-4e9278c24ea3', N'SupportURLFull')
	,(N'f555fa17-83e9-48b9-a577-4ffa1c5d104b', N'BingAdID')
	,(N'd2178b48-55e6-4a02-ba3c-6ebbd534aecd', N'BingAdUnit')
	,(N'e3214338-b852-484f-959e-a37519bc2db2', N'SiteURLFriendly')
	)
AS Source ([SettingTypeKey], [SettingTypeName])
	ON Target.[SettingTypeKey] = Source.[SettingTypeKey]
-- Update
WHEN MATCHED THEN 
	UPDATE SET [SettingTypeName] = Source.[SettingTypeName]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([SettingTypeKey], [SettingTypeName]) VALUES (Source.[SettingTypeKey], Source.[SettingTypeName])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;