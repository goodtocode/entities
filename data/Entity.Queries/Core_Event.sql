-- 
--Events and Types
--
-- Event
Use EntityData
Select	*
From	[EntityData].[Entity].[Event]
Where	EventKey = Upper('e12f9427-4cca-4e5e-ab91-fa84a7ac5a3f')
	OR  CreatedActivityKey = '5bc191a3-cd9b-4f80-a681-5e6b1a68a669'
	OR  ModifiedActivityKey = '5bc191a3-cd9b-4f80-a681-5e6b1a68a669'
Order By CreatedDate Desc
EXECUTE EntityCode.EventInfoSave @Id = '-1', @Key = 'e12f9427-4cca-4e5e-ab91-fa84a7ac5a3f', @EventGroupKey = '00000000-0000-0000-0000-000000000000', @EventTypeKey = '00000000-0000-0000-0000-000000000000', @CreatorKey = 'e8d92591-f1d7-4521-a00a-7c6581f922f7', @Name = 'Tutor After School', @Description = 'Meet you at the library for a tutor session.', @Slogan = '', @ActivityContextKey = '5bc191a3-cd9b-4f80-a681-5e6b1a68a669'

-- Event Groups
Use EntityData
Select	G.EventGroupID, G.EventGroupName, T.EventTypeID, T.EventTypeName
From	[EntityData].[Entity].[EventType] T 
Join  [EntityData].[Entity].[EventGroup] G On G.EventGroupKey = T.EventGroupKey
Order By G.EventGroupName, T.EventTypeName

-- Event Groups
Use EntityData
Select	*
From	[EntityData].[Entity].[EventGroup]

-- Type
Use EntityData
Select	EventTypeID, EventTypeName
From	[EntityData].[Entity].[EventType]
Where	EventGroupID = '26833573-F93C-47DC-9812-13A4FF7DDFB6'
Order By EventGroupID, EventTypeName
-- Type Raw
Use EntityData
Select	*
From	[Entity].EventType

-- Fix int for 00000000-0000-0000-0000-000000000000 
SET IDENTITY_INSERT [Entity].[EventType] ON
Update [Entity].[EventType]
Set	EventTypeID = -1
Where EventTypeGuid = '00000000-0000-0000-0000-000000000000'
SET IDENTITY_INSERT [Entity].[EventType] OFF

-- Transactional
Use EntityData
Select	*
From	[EntityData].[Entity].EventCoordinator	
Use EntityData
Select	R.*, e.*, g.*
From	[EntityData].[Entity].EventRSVP R
Left Join [EntityData].[Entity].Event E On R.EventID = E.EventID
Left Join [EntityData].Active.GuestListEntity G On R.GuestListEntityID = G.GuestListEntityID
Order By R.EventID

Use EntityData
Select	*
From	[EntityData].[Entity].EventRSVPStatus
--
--Detail
--
-- Type
Use EntityData
Select	*
From	[EntityData].[Entity].[EventDetailType]

--
-- Event Schedule
--

-- EventScheduleLocation
Use EntityData
Go
Select Top 100 * 
From [EntityData].[Entity].[EventScheduleLocation]
--Where EventScheduleLocationKey = '917ec35f-093d-4c39-a04e-31eda9fe7858'
Go
EXECUTE EntityCode.EventScheduleLocationSave @Id = '-1', @Key = '917ec35f-093d-4c39-a04e-31eda9fe7858', @EventKey = '929b5f5f-7009-4883-94be-3ae217df6128', @BeginDate = '1/1/1900 12:00:00 AM', @EndDate = '1/1/1900 12:00:00 AM', @LocationName = 'Your House', @LocationDescription = 'Corner of Main and Drain', @ActivityContextKey = '626e2c8b-ccd5-4e5f-80cb-03ae180db87e'