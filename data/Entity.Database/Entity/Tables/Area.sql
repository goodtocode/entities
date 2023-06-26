CREATE TABLE [Entity].[Area] (
    [AreaId]			    INT	IDENTITY (1, 1) CONSTRAINT [DF_Area_Id] NOT NULL,
    [AreaKey]			    UNIQUEIDENTIFIER	CONSTRAINT [DF_Area_Key] NOT NULL DEFAULT(NewId()),
	[Area]				    Geometry			NOT NULL,
	[CreatedDate]		    DATETIME			CONSTRAINT [DF_Area_CreatedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED ([AreaId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Area_Key] ON [Entity].[Area] ([AreaKey] Asc)
GO
