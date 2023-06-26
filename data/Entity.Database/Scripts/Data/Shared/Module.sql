--------------------------------------------------------------
-- Modules. 
--------------------------------------------------------------
MERGE INTO [Entity].[Module] AS Target 
USING (VALUES
	(N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Framework Module', N'Framework Module with Person, Business, Event and all support entities.')
	)
AS Source ([ModuleKey], [ModuleName], [ModuleDescription])
ON Target.[ModuleKey] = Source.[ModuleKey]
-- Update
WHEN MATCHED THEN 
UPDATE SET [ModuleName] = Source.[ModuleName], [ModuleDescription] = Source.[ModuleDescription]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([ModuleKey], [ModuleName], [ModuleDescription])
	VALUES (Source.[ModuleKey], Source.[ModuleName], Source.[ModuleDescription])
;
