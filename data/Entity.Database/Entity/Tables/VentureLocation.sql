CREATE TABLE [Entity].[VentureLocation] (
    [VentureLocationId]	INT IDENTITY (1, 1) CONSTRAINT [DF_VentureLocation_Id] NOT NULL,
    [VentureLocationKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_VentureLocation_Key] DEFAULT(NewId()) NOT NULL,
    [VentureKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_VentureLocation_VentureId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [LocationKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_VentureLocation_LocationId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [LocationTypeKey]			UNIQUEIDENTIFIER    CONSTRAINT [DF_VentureLocation_LocationType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_VentureLocation_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_VentureLocation_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_VentureLocation_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_VentureLocation] PRIMARY KEY CLUSTERED ([VentureLocationId] ASC),
    CONSTRAINT [FK_VentureLocation_Venture] FOREIGN KEY ([VentureKey]) REFERENCES [Entity].[Venture] ([VentureKey]),
    CONSTRAINT [FK_VentureLocation_Location] FOREIGN KEY ([LocationKey]) REFERENCES [Entity].[Location] ([LocationKey]),
    CONSTRAINT [FK_VentureLocation_LocationType] FOREIGN KEY ([LocationTypeKey]) REFERENCES [Entity].[LocationType] ([LocationTypeKey]),    
    CONSTRAINT [FK_VentureLocation_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureLocation_Key] ON [Entity].[VentureLocation] ([VentureLocationKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureLocation_All] ON [Entity].[VentureLocation] ([VentureKey] Asc, [LocationKey] Asc)
GO
