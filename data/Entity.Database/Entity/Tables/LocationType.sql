CREATE TABLE [Entity].[LocationType] (
    [LocationTypeId]           INT IDENTITY (1, 1) CONSTRAINT [DF_LocationType_LocationTypeId] NOT NULL,
	[LocationTypeKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_LocationType_LocationTypeKey] DEFAULT (NewID()) NOT NULL,
    [LocationTypeName]         NVARCHAR (50)    CONSTRAINT [DF_LocationType_LocationTypeName] DEFAULT ('') NOT NULL,
    [LocationTypeDescription]  NVARCHAR (250)   CONSTRAINT [DF_LocationType_LocationTypeDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_LocationType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_LocationType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_LocationType] PRIMARY KEY CLUSTERED ([LocationTypeId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_LocationType_Key] ON [Entity].[LocationType] ([LocationTypeKey] Asc)
GO