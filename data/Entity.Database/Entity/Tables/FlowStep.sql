CREATE TABLE [Entity].[FlowStep] (
    [FlowStepId]				INT IDENTITY (1, 1) CONSTRAINT [DF_FlowStep_FlowStepId] NOT NULL,
	[FlowStepKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_FlowStep_FlowStepKey] DEFAULT(NewId()) NOT NULL,
    [FlowStepName]			NVARCHAR (50)    CONSTRAINT [DF_FlowStep_FlowStepName] DEFAULT ('') NOT NULL,
    [FlowStepDescription]	NVARCHAR (250)   CONSTRAINT [DF_FlowStep_FlowStepDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]			DATETIME         CONSTRAINT [DF_FlowStep_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_FlowStep_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_FlowStep] PRIMARY KEY CLUSTERED ([FlowStepId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_FlowStep_Key] ON [Entity].[FlowStep] ([FlowStepKey] Asc)
GO