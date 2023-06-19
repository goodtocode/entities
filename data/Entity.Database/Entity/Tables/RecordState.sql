CREATE TABLE [Entity].[RecordState] (
    [RecordStateId]				INT CONSTRAINT [DF_RecordState_RecordStateId] NOT NULL,
	[RecordStateKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_RecordState_RecordStateKey] DEFAULT(NewId()) NOT NULL,
	[RecordStateName]			NVARCHAR (50)    CONSTRAINT [DF_RecordState_RecordStateName] DEFAULT ('') NOT NULL,
    [CreatedDate]			DATETIME    CONSTRAINT [DF_RecordState_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]			DATETIME    CONSTRAINT [DF_RecordState_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_RecordState] PRIMARY KEY CLUSTERED ([RecordStateId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_RecordState_Key] ON [Entity].[RecordState] ([RecordStateKey] Asc)
GO