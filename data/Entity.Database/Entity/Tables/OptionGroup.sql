CREATE TABLE [Entity].[OptionGroup] (
    [OptionGroupId]         INT IDENTITY (1, 1) CONSTRAINT [DF_OptionGroup_OptionGroupId] NOT NULL,
	[OptionGroupKey]		UNIQUEIDENTIFIER CONSTRAINT [DF_OptionGroup_OptionGroupKey] DEFAULT(NewId()) NOT NULL,
    [OptionGroupName]       NVARCHAR (50)    CONSTRAINT [DF_OptionGroup_OptionGroupName] DEFAULT ('') NOT NULL,
    [OptionGroupDescription] NVARCHAR (250)   CONSTRAINT [DF_OptionGroup_OptionGroupDescription] DEFAULT ('') NOT NULL,
	[OptionGroupCode]       NVARCHAR (10)    CONSTRAINT [DF_OptionGroup_OptionGroupCode] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_OptionGroup_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_OptionGroup_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_OptionGroup] PRIMARY KEY CLUSTERED ([OptionGroupId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Option_OptionGroupKey] ON [Entity].[OptionGroup] ([OptionGroupKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Option_OptionGroupCode] ON [Entity].[OptionGroup] ([OptionGroupCode] Asc)
GO