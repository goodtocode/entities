CREATE TABLE [Entity].[Option] (
    [OptionId]          INT IDENTITY (1, 1) CONSTRAINT [DF_Option_OptionId] NOT NULL,
	[OptionKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_Option_OptionKey] DEFAULT(NewId()) NOT NULL,
    [OptionGroupKey]    UNIQUEIDENTIFIER CONSTRAINT [DF_Option_OptionGroup] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [OptionName]        NVARCHAR (50)   CONSTRAINT [DF_Option_OptionName] DEFAULT ('') NOT NULL,
    [OptionDescription] NVARCHAR (250)  CONSTRAINT [DF_Option_OptionDescription] DEFAULT ('') NOT NULL,
	[OptionCode]        NVARCHAR (10)   CONSTRAINT [DF_Option_OptionCode] DEFAULT ('') NOT NULL,
    [SortOrder]         INT              CONSTRAINT [DF_Option_SortOrder] DEFAULT ((-1)) NOT NULL,
    [CreatedDate]       DATETIME         CONSTRAINT [DF_Option_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]      DATETIME         CONSTRAINT [DF_Option_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Option] PRIMARY KEY CLUSTERED ([OptionId] ASC),
    CONSTRAINT [FK_Option_OptionGroup] FOREIGN KEY ([OptionGroupKey]) REFERENCES [Entity].[OptionGroup] ([OptionGroupKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Option_OptionKey] ON [Entity].[Option] ([OptionKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Option_OptionCode] ON [Entity].[Option] ([OptionGroupKey] Asc, [OptionCode] Asc)
GO