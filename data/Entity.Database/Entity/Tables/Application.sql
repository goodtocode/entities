CREATE TABLE [Entity].[Application] (
    [ApplicationId]         INT IDENTITY (1, 1) CONSTRAINT [DF_Application_ApplicationId] NOT NULL,
	[ApplicationKey]        UNIQUEIDENTIFIER CONSTRAINT [DF_Application_ApplicationKey] DEFAULT (NewID()) NOT NULL,
    [ApplicationName]       NVARCHAR (50)    CONSTRAINT [DF_Application_ApplicationName] DEFAULT ('') NOT NULL,
	[ApplicationSlogan]		NVARCHAR (50)    CONSTRAINT [DF_Application_ApplicationSlogan] DEFAULT ('') NOT NULL,
	[SharedApplicationKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_Application_SharedApplicationKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[SharedSecret]			INT CONSTRAINT [DF_Application_SharedSecret] DEFAULT(-1) NOT NULL,
	[BusinessEntityKey]		UNIQUEIDENTIFIER CONSTRAINT [DF_Application_BusinessEntity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[PrivacyUrl]			NVARCHAR (250)   CONSTRAINT [DF_Application_PrivacyUrl] DEFAULT ('') NOT NULL,
	[TermsUrl]				NVARCHAR (250)   CONSTRAINT [DF_Application_TermsUrl] DEFAULT ('') NOT NULL,
	[TermsRevisedDate]      DATETIME         CONSTRAINT [DF_Application_TermsRevisedDate] DEFAULT (getutcdate()) NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_Application_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_Application_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED ([ApplicationId] ASC),
	CONSTRAINT [FK_Application_BusinessEntity] FOREIGN KEY ([BusinessEntityKey]) REFERENCES [Entity].[Entity] ([EntityKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Application_Key] ON [Entity].[Application] ([ApplicationKey] Asc)
Go