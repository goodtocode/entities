CREATE TABLE [Entity].[FlowSequence] (
    [FlowSequenceId]			INT IDENTITY (1, 1) CONSTRAINT [DF_FlowSequence_FlowSequenceId] NOT NULL,
	[FlowSequenceKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_FlowSequence_FlowSequenceKey] DEFAULT(NewId()) NOT NULL,
	[FlowKey]					UNIQUEIDENTIFIER CONSTRAINT [DF_FlowSequencey_Flow] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[FlowStepKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_FlowSequence_FlowStep] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[FlowSequenceApplicationKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_FlowSequence_FlowSequenceApplication] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[FlowSequenceRoute]			NVARCHAR (250)   CONSTRAINT [DF_FlowSequence_FlowSequenceRoute] DEFAULT ('') NOT NULL,	
	[SortOrder]					INT			CONSTRAINT [DF_FlowSequence_SortOrder] DEFAULT (-1) NOT NULL,	
    [CreatedDate]				DATETIME    CONSTRAINT [DF_FlowSequence_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]				DATETIME    CONSTRAINT [DF_FlowSequence_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_FlowSequence] PRIMARY KEY CLUSTERED ([FlowSequenceId] ASC),
	CONSTRAINT [FK_FlowSequence_Flow] FOREIGN KEY ([FlowKey]) REFERENCES [Entity].[Flow] ([FlowKey]),
	CONSTRAINT [FK_FlowSequence_FlowStep] FOREIGN KEY ([FlowStepKey]) REFERENCES [Entity].[FlowStep] ([FlowStepKey]),
	CONSTRAINT [FK_FlowSequence_Application] FOREIGN KEY ([FlowSequenceApplicationKey]) REFERENCES [Entity].[Application] ([ApplicationKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_FlowSequence_Key] ON [Entity].[FlowSequence] ([FlowSequenceKey] Asc)
GO