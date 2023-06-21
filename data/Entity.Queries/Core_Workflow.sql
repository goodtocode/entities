Use EntityData
Set Transaction Isolation Level Read Uncommitted
-- Workflow
Use EntityData
Select	*
From	[EntityData].[Entity].Workflow
Where WorkflowID = '41bddedf-7037-44af-a132-2865b23d5ca2'
Order By WorkflowName, WorkflowTypeID

-- Workflow Type
Use EntityData
Select	*
From	[EntityData].[Entity].WorkflowType
-- Workflow Step
Use EntityData
Select	*
From	[EntityData].[Entity].WorkflowStep
Use EntityData

-- Joined Full
Set Transaction Isolation Level Read Uncommitted
Select	WA.*, W.WorkflowName, WS.WorkflowStepName
From	[EntityData].Activity.ActivityWorkflow WA
	Left Join	[EntityData].[Entity].Workflow W On WA.WorkflowID = W.WorkflowID		
	Left Join	[EntityData].[Entity].WorkflowStep WS On WA.WorkflowStepID = WS.WorkflowStepID		
Order By WA.CreatedDate Desc

Use EntityData
Select	*
From	[EntityData].Activity.ActivityWorkflow WA
Join	[EntityData].[Entity].WorkflowStep WS
	On WA.WorkflowStepID = WS.WorkflowStepID
Join	[EntityData].[Entity].Workflow W
	On WA.WorkflowID = W.WorkflowID
Join	[EntityData].[Entity].Application A
	On WA.ApplicationID = A.ApplicationID
Order By WA.ModifiedDate Desc

--Delete From ActivityWorkflow Where ActivityWorkflowID = '25C0A415-348C-429D-ABA2-B92F3AD96B1F'
	
	
