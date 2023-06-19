CREATE TABLE [Entity].[ResourcePerson] (
    [ResourcePersonId]		INT IDENTITY (1, 1) CONSTRAINT [DF_ResourcePerson_ResourcePersonId] NOT NULL,
    [ResourcePersonKey]     UNIQUEIDENTIFIER CONSTRAINT [DF_ResourcePerson_ResourcePersonKey] DEFAULT(NewId()) NOT NULL,
	[ResourceKey]			UNIQUEIDENTIFIER         CONSTRAINT [DF_ResourceResource_Resource] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[PersonKey]				UNIQUEIDENTIFIER         CONSTRAINT [DF_ResourcePerson_Person] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER         CONSTRAINT [DF_ResourcePerson_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_ResourcePerson_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_ResourcePerson_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ResourcePerson] PRIMARY KEY CLUSTERED ([ResourcePersonId] ASC),
	CONSTRAINT [FK_ResourceResource_Resource] FOREIGN KEY ([ResourceKey]) REFERENCES [Entity].[Resource] ([ResourceKey]),
	CONSTRAINT [FK_ResourcePerson_Person] FOREIGN KEY ([PersonKey]) REFERENCES [Entity].[Person] ([PersonKey]),
    CONSTRAINT [FK_ResourcePerson_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ResourcePerson_Key] ON [Entity].[ResourcePerson] ([ResourcePersonKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ResourcePerson_Resource] ON [Entity].[ResourcePerson] ([ResourceKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ResourcePerson_Person] ON [Entity].[ResourcePerson] ([PersonKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ResourcePerson_All] ON [Entity].[ResourcePerson] ([ResourceKey] Asc, [PersonKey] Asc)
GO