CREATE TABLE [Entity].[Entity] (
    [EntityId]    INT IDENTITY (1, 1) CONSTRAINT [DF_Entity_EntityId] NOT NULL,
	[EntityKey]  UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_EntityKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]  DATETIME         CONSTRAINT [DF_Entity_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Entity_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Entity] PRIMARY KEY CLUSTERED ([EntityId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Entity_EntityKey] ON [Entity].[Entity] ([EntityKey] Asc)
GO
