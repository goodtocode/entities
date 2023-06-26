CREATE TABLE [Entity].[Venture] (
    [VentureId]          INT IDENTITY (1, 1) CONSTRAINT [DF_Venture_VentureId] NOT NULL,
	[VentureKey]          UNIQUEIDENTIFIER CONSTRAINT [DF_Venture_VentureKey] DEFAULT (NewID()) NOT NULL,
    [VentureGroupKey]     UNIQUEIDENTIFIER CONSTRAINT [DF_Venture_VentureGroup] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [VentureTypeKey]      UNIQUEIDENTIFIER CONSTRAINT [DF_Venture_VentureType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [VentureName]        NVARCHAR (50)    CONSTRAINT [DF_Venture_VentureName] DEFAULT ('') NOT NULL,
    [VentureDescription] NVARCHAR (250)   CONSTRAINT [DF_Venture_VentureDescription] DEFAULT ('') NOT NULL,
    [VentureSlogan]      NVARCHAR (50)    CONSTRAINT [DF_Venture_VentureSlogan] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Venture_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_Venture_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Venture_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Venture] PRIMARY KEY CLUSTERED ([VentureId] ASC),
    CONSTRAINT [FK_Venture_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Venture_VentureKey] ON [Entity].[Venture] ([VentureKey] Asc)
GO