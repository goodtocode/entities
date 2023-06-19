--
-- Office
--
-- Singles
Use SchedulerData
Go
Select Top 100 * From [Provider].[Office] Order By CreatedDate Desc

-- Full Join
Use SchedulerData
Go
Select Top 10 * From [Provider].[Office] O
	Join [Entity].[Business] B On O.BusinessKey = B.BusinessKey
	Join [Entity].[EntityLocation] EL On O.OfficeKey = EL.EntityKey
	Join [Entity].[Location] L On EL.LocationKey = L.LocationKey
Order By O.CreatedDate Desc

-- Stored Procedures
Use SchedulerData
Go
EXECUTE ProviderCode.OfficeInfoSave @Id = '-1', @Key = 'a3d054c2-fe55-46e9-9531-c8e998c9d6d1', @Name = 'AbcCo', @TaxNumber = '666-1', @BusinessKey = '00000000-0000-0000-0000-000000000000', @LocationKey = '00000000-0000-0000-0000-000000000000', @LocationName = '', @LocationDescription = '', @ActivityContextKey = '6329bdb4-0637-40c6-8bf1-f340672bbc80'


--
-- Office Hours
--
-- Single
Use SchedulerData
Go
Select Top 10 * From [ProviderCode].[OfficeHours] OH

-- Full Join
Use SchedulerData
Go
Select Top 10 * From [Provider].[Office] O
	Left Join [ProviderCode].[OfficeHours] OH On O.OfficeKey = OH.OfficeKey
Order By O.CreatedDate Desc


-- Stored Procedure
Use SchedulerData
Go
EXECUTE ProviderCode.OfficeHoursSave @Id = '-1', @Key = '0a3cf11c-8244-490f-b3c5-58d2cdbfb0a2', @OfficeKey = '5fd55e6f-3030-45e0-8d46-e2bd41268205', @BeginDay = '1', @EndDay = '1', @BeginTime = '1/1/1900 8:00:00 AM', @EndTime = '1/1/1900 5:00:00 PM', @ActivityContextKey = 'cb411066-d2de-47a0-9e16-9119a2593dd2'