Use EntityData
Set Transaction Isolation Level Read Uncommitted
--
--Entity
--
Use EntityData
Select	*
From	Entity.Entity C 
Join	[Entity].[Person] P On C.EntityID = P.EntityID
Select	*
From	[Entity].Business

--
--Properties
--
Use EntityData
Select	*
From	[EntityData].[Entity].[Person] P
Join [EntityData].[Entity].[PropertyEntity] PC on P.EntityID = PC.EntityID
Join [EntityData].[Entity].Property Pr on PC.PropertyID = Pr.PropertyID

--
--Interest
--
Select	*
From	InterestTable
Select	*
From	InterestEntity
Select	*
From	InterestEntity CI
Left Join	Interest I
	On CI.InterestID = I.InterestID
	
Begin Tran
Delete
From   InterestEntity
Rollback

Use EntityData
Select	*
From	InterestGroup
Select	*
From	Interest
Select	*
From	InterestSubType

--
--Guest List
--
Use EntityData
Select	*
From	GuestList
Select	*
From	GuestListEntity


--
--Properties
--
Use EntityData
Select	*
From	PropertyGroup
Select	*
From	Property
Select	*
From	PropertyEntity CP
Left Join Entity C
	On CP.EntityID = C.EntityID
Select	EntityID, Count(*)
From	PropertyEntity
Group By EntityID
Having Count(*) > 1

Select	*
From	PropertyEntity CP
Join Property P On CP.PropertyID = P.PropertyID
Join	PropertyGroup PG On P.PropertyGroupID = PG.PropertyGroupID
Order By EntityID
Select	*
From	PropertyGroup

Select	PG.PropertyGroupName, P.*
From	Property P
Join	PropertyGroup PG On P.PropertyGroupID = PG.PropertyGroupID
Order By P.PropertyGroupID 


--
--Unsubscribe
--
Use EntityData
Select	Top 100 *
From	[EntityData].[Entity].Unsubscribe U
Join [EntityData].Activity.ActivityWorkflow WA On U.ActivityWorkflowID = WA.ActivityWorkflowID 
Where U.UnsubscribeID = '48406D9F-5F7D-4D5C-889D-459048D8FCF2'

Use EntityData
Select	Top 100 *
From	[EntityData].Log.UnsubscribeDelete

