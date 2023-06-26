--
--Photo
--
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From		[EntityData].Active.PhotoEntity PC
Left Join	[EntityData].[Entity].Entity C On PC.EntityID = C.EntityID
Left Join	[EntityData].[Entity].[Person] P On C.PersonID = P.PersonID
Left Join	[EntityData].Active.Photo Ph On PC.PhotoID = PH.PhotoID


-- Photo
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	Photo

-- Types
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	*
From	[EntityData].Active.PhotoType



