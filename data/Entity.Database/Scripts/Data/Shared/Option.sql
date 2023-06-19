-------------------------------------------------------------
-- Properties
--------------------------------------------------------------
-- [Option]
MERGE Into [EntityData].[Entity].[Option] AS Target 
USING (
VALUES 
    (N'98E871B9-8E3E-452D-A61D-275CA1F42657', N'3DBC544F-9331-4FB6-B7E0-710162B15E4D', N'Venture Admin', N'Venture Admin', N'VA', 3)
    ,(N'A3509D25-E94F-4AEE-8598-5405679F4260', N'3DBC544F-9331-4FB6-B7E0-710162B15E4D', N'Venture Contributor', N'Venture Contributor', N'VC', 2)
    ,(N'23DBF692-5216-45B2-80EC-7611CCCD0517', N'3DBC544F-9331-4FB6-B7E0-710162B15E4D', N'Venture Reader', N'Venture Reader', N'VR', 1)
    ,(N'07B504A3-BE9E-4D49-9558-D3B6F82D525F', N'35B62540-E479-4430-A094-C57C4CFC5D16', N'Event Admin', N'Event Admin', N'EA', 3)
    ,(N'8DD97CDE-1860-4C0A-917A-57D5752C1070', N'35B62540-E479-4430-A094-C57C4CFC5D16', N'Event Contributor', N'Event Contributor', N'EC', 2)
    ,(N'19FC3855-7AEE-4A48-A78C-A83B75CFE4BC', N'35B62540-E479-4430-A094-C57C4CFC5D16', N'Event Reader', N'Event Reader', N'ER', 1)
	,(N'32c4a908-d63c-45e6-81c8-116b3a44d8df', N'b8605781-0627-4d57-ad9c-4830bfb5f0d5', N'Yes and they do not live at home', N'Yes and they do not live at home.', N'NH', 5)
	,(N'7c78aacf-7edb-461c-95b6-13b89541a618', N'6ffeda98-189d-4065-90f9-d6987702c4cb', N'Separated', N'Separated', N'Sep', 5)
	,(N'57745823-17cf-46a9-aa7f-370dcc7a5d4b', N'4e51ea04-1ac7-4623-9acf-cfd9cb4fab0c', N'Moderately', N'Moderately', N'Mod', 3)
	,(N'f57e9798-6e70-4887-9580-44cca5eed894', N'b997d822-c6d1-4c0f-877b-5d8e8aa6cc99', N'Male', N'Male', N'M', 1)
	,(N'080c18a0-8800-4459-b15e-50fec4af4cd4', N'4e51ea04-1ac7-4623-9acf-cfd9cb4fab0c', N'Never have', N'Never have', N'NH', 4)
	,(N'29e8cf65-521e-4ba3-a239-6b2eb6d7f34a', N'b8605781-0627-4d57-ad9c-4830bfb5f0d5', N'Yes and they sometimes live at home', N'Yes and they sometimes live at home.', N'Some', 4)
	,(N'4b81eb4a-15bd-4cc4-912f-845fda0930cc', N'6ffeda98-189d-4065-90f9-d6987702c4cb', N'Divorced', N'Divorced', N'Div', 4)
	,(N'461317fd-f7ce-4ab3-8c27-859a68c7d224', N'4e51ea04-1ac7-4623-9acf-cfd9cb4fab0c', N'Socially', N'Socially', N'Soc', 2)
	,(N'6f129903-3b96-4e73-ae28-8842eee3ded4', N'6ffeda98-189d-4065-90f9-d6987702c4cb', N'Widow/Widower', N'Widow/Widower', N'Wid', 6)
	,(N'49810f46-e1b0-47c8-a6ba-88bd2cabfa84', N'b8605781-0627-4d57-ad9c-4830bfb5f0d5', N'Not Specified', N'No', N'NS', 1)
	,(N'e1af6db7-3747-4727-aa6d-8a42372edd38', N'4e51ea04-1ac7-4623-9acf-cfd9cb4fab0c', N'Sober in recovery', N'Sober in recovery', N'Sob', 5)
	,(N'1c8a6922-e186-452e-9204-95b7d4e17c23', N'b8605781-0627-4d57-ad9c-4830bfb5f0d5', N'Yes and they always live at home', N'Yes and they always live at home.', N'Hom', 3)
	,(N'd8969ac8-1f58-406a-b89c-9acf811f6392', N'6ffeda98-189d-4065-90f9-d6987702c4cb', N'Married', N'Married', N'Mar', 3)
	,(N'b2840a53-c0d6-47bd-be54-aa0dacb2ba61', N'b8605781-0627-4d57-ad9c-4830bfb5f0d5', N'No', N'No', N'N', 2)
	,(N'7f21986a-c0ba-439d-9b60-c37437d9c1bd', N'b997d822-c6d1-4c0f-877b-5d8e8aa6cc99', N'Female', N'Female', N'F', 21)
	,(N'250d907c-77c7-4bc0-b6e6-e6d96e437edd', N'4e51ea04-1ac7-4623-9acf-cfd9cb4fab0c', N'Not Specified', N'Not Specified', N'NS', 1)
	,(N'5d360eda-cb09-4e71-b650-ecff0dc51850', N'6ffeda98-189d-4065-90f9-d6987702c4cb', N'Not Specified', N'Not Specified', N'NS', 1)
	,(N'51e83e1e-5cc1-4e02-9656-f12559b54753', N'6ffeda98-189d-4065-90f9-d6987702c4cb', N'Never Married', N'Never Married', N'Nev', 2)
	)
AS Source ([OptionKey], [OptionGroupKey], [OptionName], [OptionDescription], [OptionCode], [SortOrder])
Join [EntityData].[Entity].[OptionGroup] PG On Source.OptionGroupKey = PG.OptionGroupKey
ON Target.[OptionKey] = Source.[OptionKey]
-- Update
WHEN MATCHED THEN 
UPDATE SET [OptionGroupKey] = PG.[OptionGroupKey], [OptionName] = Source.[OptionName], [OptionDescription] = Source.[OptionDescription], [OptionCode] = Source.[OptionCode]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([OptionKey], [OptionGroupKey], [OptionName], [OptionDescription], [OptionCode], [SortOrder])
	VALUES (Source.[OptionKey], PG.[OptionGroupKey], Source.[OptionName], Source.[OptionDescription], Source.[OptionCode], Source.[SortOrder])
; -- Terminate here, when there is no DELETE logic
