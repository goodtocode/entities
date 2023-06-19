CREATE TABLE [Entity].[LocationArea] (
    [LocationAreaId]		INT IDENTITY (1, 1) CONSTRAINT [DF_LocationArea_Id] NOT NULL,
    [LocationAreaKey]       UNIQUEIDENTIFIER CONSTRAINT [DF_LLocationArea_Key] DEFAULT(NewId()) NOT NULL,
	[LocationKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_LocationArea_Location] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[AreaKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_LocationArea_Area] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]			DATETIME         CONSTRAINT [DF_LocationArea_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]			DATETIME         CONSTRAINT [DF_LocationArea_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_LocationArea] PRIMARY KEY CLUSTERED ([LocationAreaId] ASC),
	CONSTRAINT [FK_LocationArea_Location] FOREIGN KEY ([LocationKey]) REFERENCES [Entity].[Location] ([LocationKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_LocationArea_Key] ON [Entity].[LocationArea] ([LocationAreaKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_LocationArea_LocationId] ON [Entity].[LocationArea] ([LocationKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_LocationArea_All] ON [Entity].[LocationArea] ([LocationKey] Asc, [AreaKey] Asc)
GO