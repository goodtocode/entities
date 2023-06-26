--
--Entity
--
-- Government
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].[Entity].Entity C 
Join	[EntityData].[Entity].Government G On C.EntityID = G.EntityID
