--------------------------------------------------------------
-- Genders - Global data to all products
--------------------------------------------------------------
-- ISO 5218 Genders
MERGE INTO [Entity].[Gender] AS Target 
USING (VALUES (-1, N'00000000-0000-0000-0000-000000000000', N'', N'Not Supplied')
	,(0, N'5273832D-99D7-4B45-A653-45A74C012AD4', N'U', N'Unknown')
	,(1, N'CCC10950-B71D-4223-BD01-86FF1B2449BC', N'M', N'Male')
	,(2, N'FC3B6DED-E71E-4DDE-825A-4B9319B50557', N'F', N'Female')
	,(9, N'9F9100E5-06DC-407D-B67E-EFCD4785901F', N'N', N'Not Applicable')
	)
AS Source ([GenderId], [GenderKey], [GenderCode], [GenderName])
	ON Target.[GenderId] = Source.[GenderId]
-- Update
WHEN MATCHED THEN 
	UPDATE SET	[GenderCode] = Source.[GenderCode],
				[GenderName] = Source.[GenderName]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([GenderId], [GenderKey], [GenderCode], [GenderName]) 
	VALUES (Source.[GenderId], Source.[GenderKey], Source.[GenderCode], Source.[GenderName])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;