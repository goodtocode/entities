--------------------------------------------------------------
-- Properties
--------------------------------------------------------------
-- [OptionGroup]
MERGE Into [EntityData].[Entity].[OptionGroup] AS Target 
USING (VALUES 
    (N'3DBC544F-9331-4FB6-B7E0-710162B15E4D', N'Venture Roles', N'Venture Roles', N'VRO')
    ,(N'35B62540-E479-4430-A094-C57C4CFC5D16', N'Event Roles', N'Event Roles', N'ERO')
	,(N'b8605781-0627-4d57-ad9c-4830bfb5f0d5', N'Has Children', N'Has Children', N'KID')
	,(N'b997d822-c6d1-4c0f-877b-5d8e8aa6cc99', N'Gender', N'Gender', N'GEN')
	,(N'4e51ea04-1ac7-4623-9acf-cfd9cb4fab0c', N'Alcohol Use', N'Alcohol Use', N'DRI')
	,(N'6ffeda98-189d-4065-90f9-d6987702c4cb', N'Marital Status', N'Marital Status', N'MAR')
	)
AS Source ([OptionGroupKey], [OptionGroupName], [OptionGroupDescription], [OptionGroupCode])
ON Target.[OptionGroupKey] = Source.[OptionGroupKey]
-- Update
WHEN MATCHED THEN 
UPDATE SET [OptionGroupName] = Source.[OptionGroupName], [OptionGroupDescription] = Source.[OptionGroupDescription], [OptionGroupCode] = Source.[OptionGroupCode]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([OptionGroupKey], [OptionGroupName], [OptionGroupDescription], [OptionGroupCode])
	VALUES (Source.[OptionGroupKey], Source.[OptionGroupName], Source.[OptionGroupDescription], Source.[OptionGroupCode])
; -- Terminate here, when there is no DELETE logic
