CREATE TABLE [Entity].[ItemType] (
    [ItemTypeId]           INT IDENTITY (1, 1) CONSTRAINT [DF_ItemType_ItemTypeId] NOT NULL,
	[ItemTypeKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_ItemType_ItemTypeKey] DEFAULT (NewID()) NOT NULL,
    [ItemGroupKey]         UNIQUEIDENTIFIER CONSTRAINT [DF_ItemType_ItemGroupId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ItemTypeName]         NVARCHAR (50)    CONSTRAINT [DF_ItemType_ItemTypeName] DEFAULT ('') NOT NULL,
    [ItemTypeDescription]  NVARCHAR (250)   CONSTRAINT [DF_ItemType_ItemTypeDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_ItemType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_ItemType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED ([ItemTypeId] ASC),
    CONSTRAINT [FK_ItemType_ItemGroup] FOREIGN KEY ([ItemGroupKey]) REFERENCES [Entity].[ItemGroup] ([ItemGroupKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ItemType_Key] ON [Entity].[ItemType] ([ItemTypeKey] Asc)
GO