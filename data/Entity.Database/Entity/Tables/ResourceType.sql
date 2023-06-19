CREATE TABLE [Entity].[ResourceType] (
    [ResourceTypeId]           INT IDENTITY (1, 1) CONSTRAINT [DF_ResourceType_ResourceTypeId] NOT NULL,
	[ResourceTypeKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_ResourceType_ResourceTypeKey] DEFAULT (NewID()) NOT NULL,
    [ResourceTypeName]         NVARCHAR (50)    CONSTRAINT [DF_ResourceType_ResourceTypeName] DEFAULT ('') NOT NULL,
    [ResourceTypeDescription]  NVARCHAR (250)   CONSTRAINT [DF_ResourceType_ResourceTypeDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_ResourceType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_ResourceType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ResourceType] PRIMARY KEY CLUSTERED ([ResourceTypeId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ResourceType_Key] ON [Entity].[ResourceType] ([ResourceTypeKey] Asc)
GO