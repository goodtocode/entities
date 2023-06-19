--------------------------------------------------------------
-- Workflow
--------------------------------------------------------------
-- [FlowType]
MERGE INTO [Entity].[FlowType] AS Target 
USING (VALUES 
	(N'7814190A-255B-4032-A3C0-46B9EE54B3B2', N'Sessionflow', N'Sessionflow created'),
	(N'AA5CA555-23CE-4B8F-A1CA-6BBE2CF2C7E7', N'Entity Created', N'Entity (Person, Business or Event) Created'),
	(N'A06E4BDA-09B5-445E-A78B-F99003886AA5', N'Entity Edited', N'Entity (Person, Business or Event) Edited'),
	(N'A8E13DA0-1951-4C09-AE02-FC4906BC8E45', N'Entity Viewed', N'Entity (Person, Business or Event) Viewed'),
	(N'021557FD-DD8E-4F00-8C68-3D2200E32055', N'Entity Printed', N'Entity (Person, Business or Event) Printed')
	)
AS Source ([FlowTypeKey], [FlowTypeName], [FlowTypeDescription])
ON Target.[FlowTypeKey] = Source.[FlowTypeKey]
-- Update
WHEN MATCHED THEN 
UPDATE SET [FlowTypeName] = Source.[FlowTypeName], [FlowTypeDescription] = Source.[FlowTypeDescription]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([FlowTypeKey], [FlowTypeName], [FlowTypeDescription])
	VALUES (Source.[FlowTypeKey], Source.[FlowTypeName], Source.[FlowTypeDescription])
;