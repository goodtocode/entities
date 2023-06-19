--------------------------------------------------------------
-- 
--------------------------------------------------------------
--  Group
MERGE INTO [Entity].[DetailType] AS Target 
USING (VALUES 
		(N'ddc2033a-8977-49ca-85e9-1d780567f522', N'Web Site', N'Web Site'),
		(N'0a9cb93c-79ab-440d-9681-2cb461afba66', N'Hours of Operation', N'Hours of Operation'),
		(N'a74424d0-d392-4ce6-ab96-3619196ab3eb', N'Admission', N'Admission'),
		(N'9c00e926-f4a6-402b-87c8-3647b54c7b55', N'How to Entity', N'How to Entity'),
		(N'61363878-37fd-499a-943c-374650e31c3e', N'Directions', N'Directions'),
		(N'57bc7b92-2d59-4252-b087-9d3ae2d7e172', N'More Info', N'More Info'),
		(N'130aeffe-0162-4bd3-b8e1-fa6e82ff3377', N'Parking', N'Parking')
	)
AS Source ([DetailTypeKey], [DetailTypeName], [DetailTypeDescription])
ON Target.[DetailTypeKey] = Source.[DetailTypeKey]
-- Update
WHEN MATCHED THEN 
	UPDATE SET [DetailTypeName] = Source.[DetailTypeName], [DetailTypeDescription] = Source.[DetailTypeDescription]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([DetailTypeKey], [DetailTypeName], [DetailTypeDescription]) Values (Source.[DetailTypeKey], Source.[DetailTypeName], Source.[DetailTypeDescription])
; -- Terminate here, when there is no DELETE logic
-- Delete: Do not delete, this is a multi-tenant database and each tenant's DB project will maintain it's own values
--WHEN NOT MATCHED BY SOURCE THEN 
	--DELETE;

