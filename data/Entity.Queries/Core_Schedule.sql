
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

-- ScheduleLocation View
Use EntityData
Go
Select Top 10 * 
From	[EntityData].[EntityCode].[EventScheduleLocation]

-- 
-- Time
--
-- TimeRange
-- ScheduleLocation View
Use EntityData
Go
Select Top 10 * 
From	[EntityData].[Entity].[TimeRange]

-- TimeRecurring
Use EntityData
Go
Select Top 10 * 
From	[EntityData].[Entity].[TimeRecurring]

-- TimeCycle
Use EntityData
Go
Select Top 10 * 
From	[EntityData].[Entity].[TimeCycle]


