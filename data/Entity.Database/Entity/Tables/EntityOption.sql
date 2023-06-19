CREATE TABLE [Entity].[EntityOption] (
    [EntityOptionId]        INT IDENTITY (1, 1) CONSTRAINT [DF_EntityOption_EntityOptionId] NOT NULL,
    [EntityOptionKey]		UNIQUEIDENTIFIER CONSTRAINT [DF_EntityOption_EntityOptionKey] DEFAULT(NewId()) NOT NULL,
    [EntityKey]             UNIQUEIDENTIFIER CONSTRAINT [DF_EntityOption_Entity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [OptionKey]             UNIQUEIDENTIFIER CONSTRAINT [DF_EntityOption_Option] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_EntityOption_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_EntityOption_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,    
    CONSTRAINT [PK_EntityOption] PRIMARY KEY CLUSTERED ([EntityOptionId] ASC),
    CONSTRAINT [FK_EntityOption_Option] FOREIGN KEY ([OptionKey]) REFERENCES [Entity].[Option] ([OptionKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityOption_All] ON [Entity].[EntityOption] ([EntityKey] Asc, [OptionKey] Asc)
GO
