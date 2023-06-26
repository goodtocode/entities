CREATE TABLE [Entity].[FlowType] (
    [FlowTypeId]            INT IDENTITY (1, 1) CONSTRAINT [DF_FlowType_FlowTypeId] NOT NULL,
	[FlowTypeKey]		    UNIQUEIDENTIFIER CONSTRAINT [DF_FlowType_FlowTypeKey] DEFAULT(NewId()) NOT NULL,
    [FlowTypeName]          NVARCHAR (50)    CONSTRAINT [DF_FlowType_FlowTypeName] DEFAULT ('') NOT NULL,
    [FlowTypeDescription]   NVARCHAR (250)   CONSTRAINT [DF_FlowType_FlowTypeDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_FlowType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]	        DATETIME         CONSTRAINT [DF_FlowType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_FlowType] PRIMARY KEY CLUSTERED ([FlowTypeId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_FlowType_Key] ON [Entity].[FlowType] ([FlowTypeKey] Asc)
GO