--------------------------------------------------------------
-- Event
--------------------------------------------------------------
-- [EventType]
MERGE INTO [Entity].[EventType] AS Target 
USING (VALUES 
	-- Generic get together
	(N'00000000-0000-0000-0000-000000000000', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Get Together', N'Get Together'),
	-- Personal Events
	(N'502d9e5a-f88e-4a01-9d67-e3df7449d575', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Game on TV', N'Watch the game!'),
	(N'3e61891d-6c29-41a4-a0bb-15149b4a0e14', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Dinner Party', N'Dinner Party'),
	(N'afbd9678-4d6f-4963-b928-31cfdd473dd6', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Baby Shower', N'Baby Shower'),
	(N'e0d07790-7780-4217-b2d4-410a7bdf0c2b', N'11ad3246-967f-4318-b82b-b8496772db84', N'Poker Party', N'Poker Party'),
	(N'520db710-91ab-4d1c-b2af-415a06b807e5', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'BBQ', N'BBQ'),
	(N'53e6b6c2-1ee4-4a3d-bcb9-419d4c196ee3', N'11ad3246-967f-4318-b82b-b8496772db84', N'Concert', N'Concert'),
	(N'b1e32717-9042-4679-8e2f-4a2b9d6f7d10', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Birthday Party', N'Birthday Party'),
	(N'2cf9433c-a739-4b5d-8e09-5128c480fb1a', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Bridal Shower', N'Bridal Shower'),
	(N'851089a1-b4fc-4fad-8d6c-54291d5091bc', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Casino Night', N'Casino Night'),
	(N'3b0c7553-6189-49c1-b055-568d1512add1', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Comedy Night', N'Comedy Club'),
	(N'fc55aeaa-a438-4373-8d22-571177c2a282', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Costume Party', N'Costume Party'),
	(N'f4b566cb-0e01-47f5-b65b-652c350f518b', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Family Friendly Party', N'Family Friendly Party'),
	(N'14c5ffab-cc35-4f22-b73f-72080bc15977', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Girls'' Night', N'Girls'' Night'),
	(N'15bafd63-6d98-407a-952c-792e6d12b990', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'House Party', N'House Party'),
	(N'903f074b-3381-4930-8044-7d975da24013', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Housewarming', N'Housewarming'),
	(N'9e658ab2-6ca8-407c-87a0-7e670f7002a3', N'11ad3246-967f-4318-b82b-b8496772db84', N'Conference', N'Conference'),
	(N'3a71602b-62e2-4a21-9882-7fc46f85e6c5', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Pool Party', N'Pool Party'),
	(N'585bd93a-71de-46c9-a9e5-827e0310e11c', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Potluck', N'Potluck'),
	(N'09300ad4-f7b3-48ee-b779-890601ffcf8e', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Film Festival', N'Film Festival'),
	(N'b6926133-9ab8-4bf0-8e85-8ac2fd4dab8f', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Soccer Game', N'Watch the game!'),
	(N'f4ebca0f-da35-47fd-aedf-8c1790d1b7e3', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Stag Party', N'Stag Party'),
	(N'3ec6b4cf-d5bb-4214-b501-8ef486905bef', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Football Game', N'Watch the Game'),
	(N'1a2501e5-5d9b-4d7d-acae-9c40c52e7490', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Bite to Eat', N'Bite to Eat'),
	(N'c4bb559b-bfbf-4a2d-922b-99c6dcb6f0ad', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Wedding', N'Wedding'),
	(N'985e86ef-77b5-4540-ba7a-9ec74bd60fc6', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Fundraiser', N'Fundraiser'),
	(N'c808443e-b792-4f4d-a7d4-a31afa6a586a', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Movie Night', N'Movie Time'),
	-- Meetings
	(N'96233d32-ce06-4095-8fb6-9240e635e7fa', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Tradition Promises (TP)', N'Tradition Promises (TP)'),
	(N'f5936a2e-b9fa-4189-a9ca-9b884738cffe', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'BB Step Study (BS)', N'BB Step Study (BS)'),	
	(N'02871523-21ad-4216-bf35-9c94584be2ed', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Beginner (BG)', N'Beginner (BG)'),
	(N'cca5f43b-56a5-49a1-ad27-272c2d827484', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Tradition (T)', N'Tradition (T)'),
	(N'f39e2260-8c3b-4331-9418-a678d01368ab', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Big Book (BB)', N'Big Book (BB)'),
	(N'3fa22688-cd40-4e55-8390-a6b87eb43b64', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Big Book/12 & 12 (SBS)', N'Big Book/12 & 12 (SBS)'),
	(N'ea06a726-8ac5-4663-823d-b070f7ee215b', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Closed (C)', N'Closed (C)'),
	(N'e3baeacf-4749-45eb-bb21-b2a38b93e707', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Beach Party', N'Beach Party'),
	(N'c6ff1aec-4525-4013-9495-b4ee30516850', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Discussion (D)', N'Discussion (D)'),
	(N'e19cd529-908b-4b07-a845-b95e4da5ee1c', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Cup of Coffee', N'Cup of Coffee'),
	(N'dff3ff72-c7f3-410d-bdb0-bc6bb9898cc7', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Grapevine (GV)', N'Grapevine (GV)'),
	(N'e9c2273f-8727-4cc6-b20f-bd4b6ca93820', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Living Sober (LS)', N'Living Sober (LS)'),
	(N'79f42e96-7b93-4bb5-9cde-c625528582bb', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Gaming Party', N'Gaming Party'),
	(N'db670998-d0a0-4ab1-9c17-cf590f051be5', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Open (O)', N'Open (O)'),
	(N'2ecd30d4-8fe6-4ac3-89dd-df147a804d44', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Promises (P)', N'Promises (P)'),	
	(N'936162d9-317c-4ac8-81d5-e537146a80b7', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Hockey Game', N'Watch the game!'),
	(N'5322f0c6-d32a-4e35-92fb-ebf42dfab9c7', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Baseball Game', N'Watch the game!'),
	(N'aa5c0b60-837e-474c-903b-ec4d9d0d76ef', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Reflections (R)', N'Reflections (R)'),
	(N'a203c6d2-3552-491b-ac5c-f5de162b9cf1', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Basketball Game', N'Watch the game!'),
	(N'ac94a653-d43e-4ebe-b54b-f8ffe01127c0', N'26833573-f93c-47dc-9812-13a4ff7ddfb6', N'Game at the Stadium', N'Game at the Stadium'),
	(N'49a97469-098a-4fd3-8c48-fab054e868be', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Speaker Discussion (SD)', N'Speaker Discussion (SD)'),
	(N'0ac16b92-7da7-441b-8f38-fd081a6d221d', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Step (S)', N'Step (S)'),
	(N'afc3f129-a11b-4df6-a664-fea900cd3807', N'5f1092f7-0199-4b5b-a92c-27f623d37ff4', N'Step/Tradition (ST)', N'Step/Tradition (ST)')
	)
	AS Source ([EventTypeKey], [EventGroupKey], [EventTypeName], [EventTypeDescription])
	Join [Entity].[EventGroup] ET On Source.EventGroupKey = ET.EventGroupKey
ON Target.[EventTypeKey] = Source.[EventTypeKey]
-- Update
WHEN MATCHED THEN 
	UPDATE SET [EventGroupKey] = ET.[EventGroupKey], [EventTypeName] = Source.[EventTypeName], [EventTypeDescription] = Source.[EventTypeDescription]
-- Insert
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([EventTypeKey], [EventGroupKey], [EventTypeName], [EventTypeDescription]) 
		Values (Source.[EventTypeKey], ET.[EventGroupKey], Source.[EventTypeName], Source.[EventTypeDescription])
;
