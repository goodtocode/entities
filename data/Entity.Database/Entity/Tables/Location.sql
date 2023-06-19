CREATE TABLE [Entity].[Location] (
    [LocationId]            INT IDENTITY (1, 1) CONSTRAINT [DF_Location_LocationId] NOT NULL,
	[LocationKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_Location_LocationKey] DEFAULT(NewId()) NOT NULL,
    [LocationName]			NVARCHAR (50)    CONSTRAINT [DF_Location_LocationName] DEFAULT ('') NOT NULL,
    [LocationDescription]	NVARCHAR (2000)   CONSTRAINT [DF_Location_LocationDescription] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Location_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_Location_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]          DATETIME         CONSTRAINT [DF_Location_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([LocationId] ASC),
    CONSTRAINT [FK_Location_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Location_LocationKey] ON [Entity].[Location] ([LocationKey] Asc)
GO