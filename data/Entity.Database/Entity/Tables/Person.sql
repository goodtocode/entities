CREATE TABLE [Entity].[Person] (
    [PersonId]              INT IDENTITY (1, 1) CONSTRAINT [DF_Person_PersonId] NOT NULL,
	[PersonKey]		        UNIQUEIDENTIFIER CONSTRAINT [DF_Person_Entity] DEFAULT(NewId()) NOT NULL,
    [FirstName]             NVARCHAR (50)    CONSTRAINT [DF_Person_FirstName] DEFAULT ('') NOT NULL,
    [MiddleName]            NVARCHAR (50)    CONSTRAINT [DF_Person_MiddleName] DEFAULT ('') NOT NULL,
    [LastName]              NVARCHAR (50)    CONSTRAINT [DF_Person_LastName] DEFAULT ('') NOT NULL,
    [BirthDate]             DATETIME         CONSTRAINT [DF_Person_BirthDate] DEFAULT ('01-01-1900') NOT NULL,
	[GenderId]				INT			CONSTRAINT [DF_Person_GenderId] DEFAULT(-1) NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Person_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_Person_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_Person_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC),
	CONSTRAINT [FK_Person_Entity] FOREIGN KEY ([PersonKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_Person_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey]),
	CONSTRAINT [FK_Person_Gender] FOREIGN KEY ([GenderId]) REFERENCES [Entity].[Gender] ([GenderId])
);
GO
CREATE NonCLUSTERED INDEX [IX_Person_All] ON [Entity].[Person] ([FirstName] Asc, [MiddleName] Asc, [LastName] Asc, [BirthDate] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Person_Entity] ON [Entity].[Person] ([PersonKey] Asc)
GO