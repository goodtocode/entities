--
-- Exception
--
Use EntityData
Select Top 10 ExceptionLogID, Message, CreatedDate
	From	[Activity].[ExceptionLog] 
	Order by ExceptionLogID Desc

	EXECUTE EntityCode.ActivityWorkflowInsert @ActivitySessionflowKey = '00000000-0000-0000-0000-000000000000', @FlowKey = '71c39399-6976-4620-9f24-cfc7ffa64b45', @FlowStepKey = '00000000-0000-0000-0000-000000000000', @EntityKey = '1452d230-bd70-4c9c-a75b-f72609b66e35'}