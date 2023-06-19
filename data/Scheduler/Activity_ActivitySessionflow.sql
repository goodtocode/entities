--
-- Activity
--
Use EntityData
Go
Select Top 10 *
From	[EntityData].Activity.ActivitySessionflow
Order By ActivitySessionflowId Desc

EXECUTE EntityCode.ActivitySessionflowInsert @Key = 'ad9db056-1588-47c0-b654-293c0f65fda3', @FlowKey = '71c39399-6976-4620-9f24-cfc7ffa64b45', @DeviceUuid = '', @ApplicationUuid = '00000000-0000-0000-0000-000000000000', @ApplicationKey = '00000000-0000-0000-0000-000000000000', @EntityKey = '0b8ca756-ba87-4f44-bf0e-faa194898dd1', @IdentityUserName = 'DEV\rjgood', @SessionflowData = ''
EXECUTE EntityCode.ActivitySessionflowInsert @Key = '7d94f76b-9455-4893-b7f9-22d30f9cd11f', @FlowKey = '71c39399-6976-4620-9f24-cfc7ffa64b45', @DeviceUuid = '', @ApplicationUuid = '00000000-0000-0000-0000-000000000000', @ApplicationKey = '00000000-0000-0000-0000-000000000000', @EntityKey = '8cdcf93c-8923-4050-9485-0c8559f46d51', @IdentityUserName = '', @SessionflowData = ''