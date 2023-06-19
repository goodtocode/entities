
--
-- Appointment
--
-- Appointment
Use EntityData
Go
Select Top 100 * 
From [EntityData].[Entity].[Appointment]

--
-- Srored Procs
--
EXECUTE EntityCode.AppointmentInfoSave @Id = '-1', @Key = 'a0299179-cf82-4dfb-bbb3-e8299ca6447a', @Name = 'Tutor After School', @Description = 'Meet you at the library for a tutor session.', @EventKey = '00000000-0000-0000-0000-000000000000', @LocationKey = '00000000-0000-0000-0000-000000000000', @BeginDate = '1/1/1900 12:00:00 AM', @EndDate = '1/1/1900 12:00:00 AM', @ActivityContextKey = 'f4a1ab5e-b15c-497e-9004-75c6e2236a14'