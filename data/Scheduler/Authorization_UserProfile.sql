--
-- Application
--
Use vGoEntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	vGo[EntityData].[Entity].Application

--
-- Application Log
--
Use vGoEntityData
Set Transaction Isolation Level Read Uncommitted
Select	Top 100 *
From	vGo[EntityData].Log.ApplicationLog
Order By CreatedDate Desc

--
-- User Profile
--
Use VGOSecurity
Set Transaction Isolation Level Read Uncommitted
Select	*
From	vGo[EntityData].Auth.[AspNetUsers] UP
Left Join	vGo[EntityData].[Entity].Contact C On UP.ContactID = C.ContactID
Left Join	vGo[EntityData].[Entity].[Person] P On C.PersonID = P.PersonID

Select NewID()
--
-- Logon
--
Use vGoEntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	vGo[EntityData].[Entity].Contact
Select	*
From	vGo[EntityData].[Entity].Logon
Select	*
From	vGo[EntityData].[Entity].[Person]
Select	*
From	vGo[EntityData].[Entity].LogonType

Select	*
From	vGo[EntityData].[Entity].WorkflowStep
Select	*
From	vGo[EntityData].[Entity].WorkflowType
Select	*
From	vGo[EntityData].[Entity].Workflow

--
-- Single user record
--
Use vGoEntityData
Set Transaction Isolation Level Read Uncommitted
Select	P.FirstNAme, P.LastName, L.UserName, L.AcceptedTermsDate, WS.WorkflowStepName
From	vGo[EntityData].[Entity].Contact C
Left Join	vGo[EntityData].[Entity].[Person] P On C.PersonID = P.PersonID
Left Join	vGo[EntityData].[Entity].Logon L On C.ContactID = L.ContactID
Left Join	vGo[EntityData].[Entity].WorkflowStep WS On L.WorkflowStepID = WS.WorkflowStepID

-- Web logos
-- Exec vGo[EntityData].DBA.ApplicationImageUpdate '3C272F13-FB34-4550-BD09-6BE825ACB485', 'ApplicationLogoSite', 'C:\Backup\Uploads\ActiveSobersLogo.jpg'
