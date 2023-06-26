--------------------------------------------------------------
-- Flows
--------------------------------------------------------------
MERGE INTO [Entity].[Flow] AS Target 
USING (VALUES 
	-- Flow
	(N'71C39399-6976-4620-9F24-CFC7FFA64B45', N'7814190A-255B-4032-A3C0-46B9EE54B3B2', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Sessionflow created', N'A session flow has been executed.', 3600, 720, 0)
	-- People
	,(N'3C0217D8-33C1-4623-9D9E-1F615E936AAE', N'AA5CA555-23CE-4B8F-A1CA-6BBE2CF2C7E7', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Person Created', N'Person Created', 3600, 720, 1)
	,(N'29EE0791-A757-40B8-A918-3B81C07AC880', N'A06E4BDA-09B5-445E-A78B-F99003886AA5', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Person Profile Edited', N'Person Profile Edited', 3600, 720, 0)
	,(N'07079A37-0317-433D-9FDA-E29C42D123CA', N'A8E13DA0-1951-4C09-AE02-FC4906BC8E45', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Person Profile Viewed', N'Person Profile Viewed', 3600, 720, 0)
	-- Business
	,(N'81BB8843-1707-416E-B5F3-0DFE319D120A', N'AA5CA555-23CE-4B8F-A1CA-6BBE2CF2C7E7', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Business Created', N'Business Created', 3600, 720, 1)
	,(N'4E885585-2133-443F-9E27-FEF4D374233A', N'A06E4BDA-09B5-445E-A78B-F99003886AA5', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Business Profile Edited', N'Business Profile Edited', 3600, 720, 0)
	,(N'E7F3181F-D9A2-46BF-934C-AFC403BB0979', N'A8E13DA0-1951-4C09-AE02-FC4906BC8E45', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Business Profile Viewed', N'Business Profile Viewed', 3600, 720, 0)
	-- Events	
	,(N'D6BA7173-5E28-40B0-B56E-C1C9BF3E7DF0', N'AA5CA555-23CE-4B8F-A1CA-6BBE2CF2C7E7', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Event Created', N'Event Created', 3600, 720, 0)
	,(N'BDCFB4CD-9125-41D7-9303-49B844E219F5', N'A06E4BDA-09B5-445E-A78B-F99003886AA5', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Event Info Changed', N'Event Info Changed', 3600, 720, 0)
	,(N'C23E767F-3AA1-4FFE-BFF2-7A23C1C54A4E', N'A06E4BDA-09B5-445E-A78B-F99003886AA5', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Event Detail Changed', N'Event Detail Changed', 3600, 720, 0)
	,(N'8083FF2D-1FBE-4B66-B64D-D4B1E1188AD2', N'A06E4BDA-09B5-445E-A78B-F99003886AA5', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Event Time/Location Changed', N'Event Time/Location Changed', 3600, 720, 0)
	,(N'FA038D4C-CC5B-4C41-8CE3-18AA0C3CAB7D', N'A8E13DA0-1951-4C09-AE02-FC4906BC8E45', N'FED60864-3604-407E-8379-BEA5823F7CA1', N'Event Viewed', N'Event Viewed', 3600, 720, 0)
	)
	AS Source ([FlowKey], [FlowTypeKey], [ModuleKey], [FlowName], [FlowDescription], [TimeoutInSeconds], [RecordDeleteInMinutes], [NonRepeatable])
	Join [Entity].[FlowType] FT On Source.FlowTypeKey = FT.FlowTypeKey
	Join [Entity].[Module] M On Source.ModuleKey = M.ModuleKey
ON Target.[FlowKey] = Source.[FlowKey]
-- Update
WHEN MATCHED THEN 
UPDATE SET [FlowTypeKey] = FT.[FlowTypeKey], [ModuleKey] = M.[ModuleKey], [FlowName] = Source.[FlowName], [FlowDescription] = Source.[FlowDescription], 
		[TimeoutInSeconds] = Source.[TimeoutInSeconds], [RecordDeleteInMinutes] = Source.[RecordDeleteInMinutes], [NonRepeatable] = Source.[NonRepeatable]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([FlowKey], [FlowTypeKey], [ModuleKey], [FlowName], [FlowDescription], [TimeoutInSeconds], [RecordDeleteInMinutes], [NonRepeatable])
	Values (Source.[FlowKey], FT.[FlowTypeKey], M.[ModuleKey], Source.[FlowName], Source.[FlowDescription], Source.[TimeoutInSeconds], Source.[RecordDeleteInMinutes], Source.[NonRepeatable])
;
