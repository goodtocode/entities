--
--Entity
--
-- Person
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	Entity.Entity C 
Join	[Entity].[Person] P On C.EntityID = P.EntityID
-- Business
Select	*
From	Entity.Entity C 
Join	[Entity].Business B On C.EntityID = B.EntityID
Select Newid()
--
-- Property
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	PG.PropertyGroupName, P.PropertyID, P.PropertyName--, P.PropertyCode
From	[EntityData].[Entity].PropertyGroup PG
Left Join	[EntityData].[Entity].Property P On PG.PropertyGroupID = P.PropertyGroupID

--
-- Property Entity
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].[Entity].[Person] P
Join [EntityData].[Entity].[PropertyEntity] PC on P.EntityID = PC.EntityID
Join [EntityData].[Entity].Property Pr on PC.PropertyID = Pr.PropertyID

