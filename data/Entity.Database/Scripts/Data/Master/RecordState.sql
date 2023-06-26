--------------------------------------------------------------
-- RecordState - Global data to all products
--------------------------------------------------------------
-- RecordState
MERGE INTO [Entity].[RecordState] AS Target 
USING (VALUES (-1, N'00000000-0000-0000-0000-000000000000', N'Default')
	,(1, N'F3B57E0D-9213-425C-B86B-405E46EB37AA', N'Read-only')
	,(2, N'5A5DAEB7-235A-4E00-9AAB-99C1D96ED5B5', N'Historical')
    ,(4, N'081C6A5B-0817-4161-A3AD-AD7924BEA874', N'Deleted')
	)
AS Source ([RecordStateId], [RecordStateKey], [RecordStateName])
	ON Target.[RecordStateKey] = Source.[RecordStateKey]
-- Update
WHEN MATCHED THEN 
	UPDATE SET [RecordStateName] = Source.[RecordStateName]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([RecordStateId], [RecordStateKey], [RecordStateName]) VALUES (Source.[RecordStateId], Source.[RecordStateKey], Source.[RecordStateName])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;