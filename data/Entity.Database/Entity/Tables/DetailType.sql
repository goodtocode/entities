CREATE TABLE [Entity].[DetailType] (
    [DetailTypeId]          INT IDENTITY (1, 1) CONSTRAINT [DF_DetailType_DetailTypeId] NOT NULL,
	[DetailTypeKey]          UNIQUEIDENTIFIER CONSTRAINT [DF_DetailType_DetailTypeKey] DEFAULT (NewId()) NOT NULL,
    [DetailTypeName]        NVARCHAR (50)    CONSTRAINT [DF_DetailType_DetailTypeName] DEFAULT ('') NOT NULL,
    [DetailTypeDescription] NVARCHAR (250)   CONSTRAINT [DF_DetailType_DetailTypeDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]                DATETIME         CONSTRAINT [DF_DetailType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_DetailType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_DetailType] PRIMARY KEY CLUSTERED ([DetailTypeId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_DetailType_Key] ON [Entity].[DetailType] ([DetailTypeKey] Asc)
GO