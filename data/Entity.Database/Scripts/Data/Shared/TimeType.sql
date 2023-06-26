--------------------------------------------------------------
-- Time
--------------------------------------------------------------
-- [TimeType]
MERGE INTO [Entity].[TimeType] AS Target 
USING (VALUES 
	(N'00000000-0000-0000-0000-000000000000', N'Available', N'Available', 1),
	(N'DAF555C1-ACD9-42AE-870D-8907B3A6D8DB', N'Unavailable', N'Unavailable for use', -1),
	(N'A832400B-3F9C-4AD4-AF29-5BE50079201C', N'Holiday', N'Holiday time slot', -1)
	)
AS Source ([TimeTypeKey], [TimeTypeName], [TimeTypeDescription], [TimeBehavior])
ON Target.[TimeTypeKey] = Source.[TimeTypeKey]
-- Update
WHEN MATCHED THEN 
UPDATE SET [TimeTypeName] = Source.[TimeTypeName], [TimeTypeDescription] = Source.[TimeTypeDescription], [TimeBehavior] = Source.[TimeBehavior]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([TimeTypeKey], [TimeTypeName], [TimeTypeDescription], [TimeBehavior])
	VALUES (Source.[TimeTypeKey], Source.[TimeTypeName], Source.[TimeTypeDescription], Source.[TimeBehavior])
;