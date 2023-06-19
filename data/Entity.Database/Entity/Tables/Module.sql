CREATE TABLE [Entity].[Module] (
    [ModuleId]				INT IDENTITY (1, 1) CONSTRAINT [DF_Module_ModuleId] NOT NULL,
	[ModuleKey]			    UNIQUEIDENTIFIER CONSTRAINT [DF_Module_ModuleKey] DEFAULT(NewId()) NOT NULL,
    [ModuleName]			NVARCHAR (50)    CONSTRAINT [DF_Module_ModuleName] DEFAULT ('') NOT NULL,
	[ModuleDescription]		NVARCHAR (250)    CONSTRAINT [DF_Module_ModuleDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_Module_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_Module_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([ModuleId] ASC),
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Module_ModuleKey] ON [Entity].[Module] ([ModuleKey] Asc)
GO
