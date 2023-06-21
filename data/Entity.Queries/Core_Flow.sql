-- 
-- Flow
--
-- Raw table
Use EntityData
Go
Select Top 100 *
From [EntityData].[Entity].[Flow]
-- View
Use EntityData
Go
Select Top 100 *
From [EntityData].[EntityCode].[FlowInfo]

-- 
-- Flow Sequence
--
-- Raw table
Use EntityData
Go
Select Top 100 *
From [EntityData].[Entity].[FlowSequence]

-- 
-- Flow Step
--
-- Raw table
Use EntityData
Go
Select Top 100 *
From [EntityData].[Entity].[FlowStep]

-- ActivitySessionflow
Use EntityData
Go
Select Top 100 *
From [EntityData].[Activity].[ActivitySessionflow]
Order By ActivitySessionflowID Desc
-- View
Select Top 100 *
From [EntityData].[Activity].[ActivitySessionflow]
