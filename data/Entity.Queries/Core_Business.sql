--
-- Business
--
-- Business raw
Use EntityData
Go
Select	Top 100 *
From	[EntityData].[Entity].Business

-- Business joined
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].[Entity].Entity C 
Join	[EntityData].[Entity].Business B On C.EntityKey = B.EntityKey

--
-- EntityCode
--
-- BusinessInfoSave
Use EntityData
Go
EXECUTE EntityCode.BusinessInfoSave @Id = '-1', @Key = '668b984c-4dc1-40ad-bf8b-805742b76f32', @Name = 'Databook', @TaxNumber = '2005-2019', @ActivityContextKey = 'd52a609e-642d-41b9-8a01-0c306283da78'