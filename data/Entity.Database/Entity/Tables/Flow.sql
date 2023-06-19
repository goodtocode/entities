CREATE TABLE [Entity].[Flow] (
    [FlowId]				INT IDENTITY (1, 1) CONSTRAINT [DF_Flow_Id] NOT NULL,
	[FlowKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_Flow_Key] DEFAULT(NewId()) NOT NULL,
    [FlowTypeKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_Flow_FlowType] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[ModuleKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_Flow_ModuleId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [FlowName]				NVARCHAR (50)   CONSTRAINT [DF_Flow_FlowName] DEFAULT ('') NOT NULL,
    [FlowDescription]		NVARCHAR (250)  CONSTRAINT [DF_Flow_FlowDescription] DEFAULT ('') NOT NULL,
    [NonRepeatable]			BIT         CONSTRAINT [DF_Flow_NonRepeatable] DEFAULT ((0)) NOT NULL,
	[TimeoutInSeconds]		INT		CONSTRAINT [DF_Flow_TimeoutInSeconds] DEFAULT (-1) NOT NULL,	
	[RecordDeleteInMinutes]	INT		CONSTRAINT [DF_Flow_RecordDeleteInMinutes] DEFAULT (-1) NOT NULL,
    [CreatedDate]			DATETIME    CONSTRAINT [DF_Flow_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]			DATETIME    CONSTRAINT [DF_Flow_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Flow] PRIMARY KEY CLUSTERED ([FlowId] ASC),
    CONSTRAINT [FK_Flow_FlowType] FOREIGN KEY ([FlowTypeKey]) REFERENCES [Entity].[FlowType] ([FlowTypeKey]),
	CONSTRAINT [FK_Flow_Module] FOREIGN KEY ([ModuleKey]) REFERENCES [Entity].[Module] ([ModuleKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Flow_Key] ON [Entity].[Flow] ([FlowKey] Asc)
GO