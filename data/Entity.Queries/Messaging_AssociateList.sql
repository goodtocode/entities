--
-- Property
--
Use EntityData
Select	PG.PropertyGroupName, P.PropertyID, P.PropertyName--, P.PropertyCode
From	[EntityData].[Entity].PropertyGroup PG
Left Join	[EntityData].[Entity].Property P On PG.PropertyGroupID = P.PropertyGroupID

--
-- Property Entity
--
Use EntityData
Select	*
From	[EntityData].[Entity].[Person] P
Join [EntityData].[Entity].[PropertyEntity] PC on P.EntityID = PC.EntityID
Join [EntityData].[Entity].Property Pr on PC.PropertyID = Pr.PropertyID
