CREATE TABLE [Entity].[ItemGroup] (
    [ItemGroupId]          INT IDENTITY (1, 1) CONSTRAINT [DF_ItemGroup_ItemGroupId] NOT NULL,
	[ItemGroupKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_ItemGroup_ItemGroupKey] DEFAULT (NewID()) NOT NULL,
    [ItemGroupName]        NVARCHAR (50)    CONSTRAINT [DF_ItemGroup_ItemGroupName] DEFAULT ('') NOT NULL,
    [ItemGroupDescription] NVARCHAR (250)   CONSTRAINT [DF_ItemGroup_ItemGroupDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_ItemGroup_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_ItemGroup_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ItemGroup] PRIMARY KEY CLUSTERED ([ItemGroupId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ItemGroup_Key] ON [Entity].[ItemGroup] ([ItemGroupKey] Asc)
GO