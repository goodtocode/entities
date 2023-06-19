---
-- GoodToCodeData: Inserts all GoodToCode data, and one sandbox applicationId associated to GoodToCode. 
---

--------------------------------------------------------------
-- Initialize
--------------------------------------------------------------
Declare @EntityKey UNIQUEIDENTIFIER = N'CF4D5026-958F-440E-8DFE-342DD48C5AFE'
Declare @SandboxApplicationKey UNIQUEIDENTIFIER = N'1EE3F6EC-59A7-4FD3-91D7-22AE3E20D412'
Declare @ActiveSoversApplicationKey UNIQUEIDENTIFIER = N'3C272F13-FB34-4550-BD09-6BE825ACB485'
Declare @FrameworkModuleKey UNIQUEIDENTIFIER = N'FED60864-3604-407E-8379-BEA5823F7CA1'
Declare @FlowStepKey Uniqueidentifier = '3767f875-7e3d-4f12-b85d-61e31e6d43f1'

--------------------------------------------------------------
-- Entity - Need for all other records
--------------------------------------------------------------
Use [EntityData]
MERGE INTO [Entity].[Entity] AS Target 
USING (VALUES 
	(@EntityKey)
	)
	AS Source ([EntityKey])
ON Target.[EntityKey] = Source.[EntityKey]
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([EntityKey])
		VALUES (Source.[EntityKey])
;

--------------------------------------------------------------
-- Application - Need for all other records
--------------------------------------------------------------
-- Application Record
Use [EntityData]
MERGE INTO [Entity].[Application] AS Target 
USING (VALUES
	(@SandboxApplicationKey, @EntityKey, N'GoodToCode Sandbox App', N'GoodToCode Sandbox App for development and testing', N'http://www.GoodToCode.com/Policy/Privacy.html', N'http://www.GoodToCode.com/Policy/Terms.html', GetUTCDate())
	)
	AS Source ([ApplicationKey], [BusinessEntityKey], [ApplicationName], [ApplicationSlogan], [PrivacyUrl], [TermsUrl], [TermsRevisedDate])
ON Target.[ApplicationKey] = Source.[ApplicationKey]
WHEN MATCHED THEN 
	UPDATE SET [ApplicationName] = Source.[ApplicationName], [ApplicationSlogan] = Source.[ApplicationSlogan], [PrivacyUrl] = Source.[PrivacyUrl], [TermsUrl] = Source.[TermsUrl], [TermsRevisedDate] =Source.[TermsRevisedDate]
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([ApplicationKey], [BusinessEntityKey], [ApplicationName], [ApplicationSlogan], [PrivacyUrl], [TermsUrl], [TermsRevisedDate])
		VALUES (Source.[ApplicationKey], Source.[BusinessEntityKey], Source.[ApplicationName], Source.[ApplicationSlogan], Source.[PrivacyUrl], Source.[TermsUrl], Source.[TermsRevisedDate])
;

--------------------------------------------------------------
-- Business
--------------------------------------------------------------
-- Business Record
Use [EntityData]
MERGE INTO [Entity].[Business] AS Target 
USING (VALUES 
	(@EntityKey, N'GoodToCode')
	)
	AS Source ([BusinessKey], [BusinessName]) 
ON Target.[BusinessKey] = Source.[BusinessKey]
WHEN MATCHED THEN 
	UPDATE SET [BusinessName] = Source.[BusinessName]
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([BusinessKey], [BusinessName]) 
		VALUES (Source.[BusinessKey], Source.[BusinessName])
;