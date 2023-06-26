--
-- Activity
--
Use EntityData
Select Top 10 *
From	[EntityData].Activity.Activity
Where	ActivityID Not In (Select ActivityID From [EntityData].Activity.ActivitySessionflow)
Order By ActivityID Desc

-- table
Select top 10 *
From [EntityData].Activity.Activity

-- view
Select top 10 *
From [EntityData].BaseCode.ActivitySessionflow

Select newid()