--------------------------------------------------------------
-- Workflow
--------------------------------------------------------------
-- [FlowStep]
MERGE INTO [Entity].[FlowStep] AS Target 
USING (VALUES 
	(N'00000000-0000-0000-0000-000000000000', N'Unprocessed', N'Unprocessed. This should always be the first step in any workflow.')
	,(N'e18ee532-2431-40f3-b696-2435fa7720a4', N'Pending Next Step', N'Pending another step, defined by the process data condition.')
	,(N'05f52306-143e-4a28-a669-5370428bcb32', N'Failed: Completed Previously', N'This workflow can not be ran twice.')	
	,(N'8eef8d96-9dbe-449b-9eae-a2e6d34f7e90', N'Failed: Validation Failed', N'Not validated exception. Failed workflow.')	
	,(N'8f952f23-5289-4bbd-82c5-1677a8f38858', N'Failed: Payment Failed', N'Payment failed exception. Failed workflow.')
	,(N'dcbca742-564c-40a8-b6c1-1d8211ac7297', N'Failed: Not Authorized', N'Not authorized exception. Failed workflow.')
	,(N'b6d4a2aa-d503-4200-b1c0-009629d7d6b9', N'Failed: Unexpected Exception', N'Unexpected exception. Failed workflow.')
	,(N'3767f875-7e3d-4f12-b85d-61e31e6d43f1', N'Completed', N'Completed. This should always be the last step in any workflow.')
	)
AS Source ([FlowStepKey], [FlowStepName], [FlowStepDescription])
ON Target.[FlowStepKey] = Source.[FlowStepKey]
-- Update
WHEN MATCHED THEN 
UPDATE SET [FlowStepName] = Source.[FlowStepName], [FlowStepDescription] = Source.[FlowStepDescription]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([FlowStepKey], [FlowStepName], [FlowStepDescription])
	Values (Source.[FlowStepKey], Source.[FlowStepName], Source.[FlowStepDescription])
;