--
-- Unsubscrube
--
Use EntityData
Select	*
From	[EntityData].[Entity].Unsubscribe
-- Log
Use EntityData
Select	Top 100 *
FROM [EntityData].Log.[UnsubscribeDelete]
