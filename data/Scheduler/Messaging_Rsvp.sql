
--
--RSVP
--
-- EventRSVP
Use EntityData
Select	*
From	[EntityData].[Entity].EventRSVP R
Join [EntityData].Active.GuestListEntity G On R.GuestListEntityID = G.GuestListEntityID
-- Statuses
Use EntityData
Select	*
From	[EntityData].[Entity].EventRSVPStatus
-- EXEC DBA.RSVPStatusImageUpdate '7BE9F988-39D9-4278-9867-1A3419E06217', 'c:\backup\uploads\FaceQuestion.jpg'
--00000000-0000-0000-0000-000000000000	NoReply
--7BE9F988-39D9-4278-9867-1A3419E06217	Maybe
--1BD8C086-F0B4-4310-B1D2-3B80B9033399	Yes
--CB43D125-17BD-42A0-82A7-CE4DE56B2D1B	No