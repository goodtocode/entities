--
--
--
-- Activity log
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	Top 1000 *
From	EntityData.Activity.ActivityContext
-- Exception log
Use EntityData
Set Transaction Isolation Level Read Uncommitted
Select	Top 1000 *
From	EntityData.Activity.ExceptionLog
Order By ExceptionLogId Desc




sp_who
kill 53