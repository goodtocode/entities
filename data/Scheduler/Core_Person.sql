--
-- Person
--
-- Person full
Use [EntityData]
Go
Select	Top 100 *
From	[EntityData].[Entity].[Person] P 
Left Join	[EntityData].[Entity].Entity E On P.EntityID = E.EntityID
Left Join	[EntityData].[Entity].[Gender] G On P.GenderID = G.GenderID
Order By P.Createddate desc

-- Person raw
Use [EntityData]
Go
Select *
From [EntityData].[Entity].[Person]
-- Gender raw
Use [EntityData]
Go
Select *
From [EntityData].[Entity].[Gender]

--
-- EntiteCode.Person
--
EXECUTE EntityCode.PersonInfoSave @Id = '-1', @Key = 'a2c2c76e-d43c-4670-907c-5ad088795ec8', @FirstName = 'FirstTest', @MiddleName = 'MiddleTest', @LastName = 'LastTest', @BirthDate = '3/30/1981 12:00:00 AM', @GenderCode = '', @ActivityContextKey = '7523641f-497d-47c6-8023-abbf98a27b20'

-- Test quick save: Insert into activity, then save person
Declare @ActivityContextID int
Select @ActivityContextID = Max(ActivityID) From [EntityData].Activity.Activity
Exec [EntityData].[BaseCode].PersonInfoSave '00000000-0000-0000-0000-000000000000', 'FirstTest', 'MiddleTest', 'LastTest', '3/30/1981', 0, @ActivityContextID

-- Person joined
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	Top 100 *
From	[EntityData].[Entity].Entity C 
Join	[EntityData].[Entity].[Person] P On C.EntityID = P.EntityID
Order By P.Createddate desc

-- Persons ActivityWorkflow
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	Top 100 *
From	[EntityData].Activity.ActivityWorkflow WA
Join	[EntityData].[Entity].[Person] P On WA.EntityID = P.EntityID
Order By WA.CreatedDate


-- Person Save
Use EntityData
Truncate Table	EntityData.[DataTier].[ExceptionLog]
Exec [EntityData].[BaseCode].PersonInfoSave '00000000-0000-0000-0000-000000000000', 'FirstTest', 'MiddleTest', 'LastTest', '03/31/1981', 1
Select	* From	EntityData.[DataTier].[ExceptionLog]
