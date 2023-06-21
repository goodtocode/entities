--
-- User Profile
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].dbo.[AspNetUsers] UP
--Left Join	[EntityData].[Entity].Entity C On UP.EntityID = C.EntityID
--Left Join	[EntityData].[Entity].[Person] P On C.PersonID = P.PersonID

--
-- Logon
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].[Entity].Entity
Select	*
From	[EntityData].[Entity].Logon
Select	*
From	[EntityData].[Entity].[Person]
Select	*
From	[EntityData].[Entity].LogonType

Select	*
From	[EntityData].[Entity].WorkflowStep
Select	*
From	[EntityData].[Entity].WorkflowType
Select	*
From	[EntityData].[Entity].Workflow

--
-- Single user record
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	P.FirstNAme, P.LastName, L.UserName, L.AcceptedTermsDate, WS.WorkflowStepName
From	[EntityData].[Entity].Entity C
Left Join	[EntityData].[Entity].[Person] P On C.PersonID = P.PersonID
Left Join	[EntityData].[Entity].Logon L On C.EntityID = L.EntityID
Left Join	[EntityData].[Entity].WorkflowStep WS On L.WorkflowStepID = WS.WorkflowStepID

-- Web logos
-- Exec [EntityData].DBA.ApplicationImageUpdate '3C272F13-FB34-4550-BD09-6BE825ACB485', 'ApplicationLogoSite', 'C:\Backup\Uploads\ActiveSobersLogo.jpg'

--
-- Application
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].[Entity].Application

--
-- Application Log
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	Top 100 *
From	[EntityData].Log.ApplicationLog
Order By CreatedDate Desc
