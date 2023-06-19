--------------------------------------------------------------
-- Event
--------------------------------------------------------------
-- Event Group
MERGE INTO [Entity].[EventGroup] AS Target 
USING (VALUES 
	(N'00000000-0000-0000-0000-000000000000', N'None', N'No group (default.)'),
    (N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Get Together', N'Get together for a personal event. Has invite emails. Has RSVP.'),
	(N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Meeting', N'Recurring meeting. Initial invite email. Has RSVP.'),
	(N'784e9cd6-aa75-4023-9220-b40318733339', N'Experience', N'Personal experience. Does not have invite emails. No RSVP.'),
	(N'11ad3246-967f-4318-b82b-b8496772db84', N'Public', N'Public event without invite emails. Has RSVP.')
	)
AS Source ([EventGroupKey], [EventGroupName], [EventGroupDescription])
ON Target.[EventGroupKey] = Source.[EventGroupKey]
-- Update
WHEN MATCHED THEN 
	UPDATE SET [EventGroupName] = Source.[EventGroupName], [EventGroupDescription] = Source.[EventGroupDescription]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([EventGroupKey], [EventGroupName], [EventGroupDescription]) Values (Source.[EventGroupKey], Source.[EventGroupName], Source.[EventGroupDescription])
-- This table drives workflows and UIs. Must not be extended without inner working knowledge. 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;
