CREATE TABLE [Entity].[SlotLocation] (
    [SlotLocationId]    INT IDENTITY (1, 1) CONSTRAINT [DF_SlotLocation_SlotLocationId] NOT NULL,
    [SlotLocationKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_SlotLocation_SlotLocationKey] DEFAULT(NewId()) NOT NULL,
	[SlotKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_SlotLocation_SlotKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[LocationKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_SlotLocation_LocationKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [LocationTypeKey]			UNIQUEIDENTIFIER    CONSTRAINT [DF_SlotLocation_LocationType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_SlotLocation_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]			DATETIME         CONSTRAINT [DF_SlotLocation_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]			DATETIME         CONSTRAINT [DF_SlotLocation_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_SlotLocation] PRIMARY KEY CLUSTERED ([SlotLocationId] ASC),
	CONSTRAINT [FK_SlotLocation_Slot] FOREIGN KEY ([SlotKey]) REFERENCES [Entity].[Slot] ([SlotKey]),
	CONSTRAINT [FK_SlotLocation_Location] FOREIGN KEY ([LocationKey]) REFERENCES [Entity].[Location] ([LocationKey]),
    CONSTRAINT [FK_SlotLocation_LocationType] FOREIGN KEY ([LocationTypeKey]) REFERENCES [Entity].[LocationType] ([LocationTypeKey]),    
    CONSTRAINT [FK_SlotLocation_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_SlotLocation_Key] ON [Entity].[SlotLocation] ([SlotLocationKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_SlotLocation_Slot] ON [Entity].[SlotLocation] ([SlotKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_SlotLocation_All] ON [Entity].[SlotLocation] ([SlotKey] Asc, [LocationKey] Asc)
GO