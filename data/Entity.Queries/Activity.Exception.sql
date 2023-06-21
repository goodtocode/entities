--
-- Exception log
--
Use FoundationData
Select Top 100 *
	From Activity.ExceptionLog
	Order By CreatedDate Desc

Begin Tran
Delete From Activity.ExceptionLog Where CreatedDate < GetUTCDate()
Commit
