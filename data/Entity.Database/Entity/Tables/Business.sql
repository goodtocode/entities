CREATE TABLE [Entity].[Business] (
    [BusinessId]	        INT IDENTITY (1, 1) CONSTRAINT [DF_Business_Business] NOT NULL,
	[BusinessKey]		    UNIQUEIDENTIFIER				CONSTRAINT [DF_Business_Entity] DEFAULT(NewId()) NOT NULL,	
    [BusinessName]	        NVARCHAR (50)    CONSTRAINT [DF_Business_BusinessName] DEFAULT ('') NOT NULL,
    [TaxNumber]		        NVARCHAR (20)    CONSTRAINT [DF_Business_TaxNumber] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Business_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]	        DATETIME         CONSTRAINT [DF_Business_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]	        DATETIME         CONSTRAINT [DF_Business_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Business] PRIMARY KEY CLUSTERED ([BusinessId] ASC),
	CONSTRAINT [FK_Business_Entity] FOREIGN KEY ([BusinessKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_Business_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_BusinessEntity_Entity] ON [Entity].[Business] ([BusinessKey] Asc)
GO
