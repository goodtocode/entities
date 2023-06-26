CREATE TABLE [Entity].[SlotTimeRange] (
    [SlotTimeRangeId]   INT IDENTITY (1, 1) CONSTRAINT [DF_SlotTimeRange_SlotTimeRangeId] NOT NULL,
    [SlotTimeRangeKey]  UNIQUEIDENTIFIER CONSTRAINT [DF_Application_SlotTimeRangeKey] DEFAULT (NewId()) NOT NULL,
	[SlotKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotTimeRange_SlotId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[TimeRangeKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotTimeRange_TimeRangeId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [TimeTypeKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotTimeRange_TimeType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_SlotTimeRange_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_SlotTimeRange_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_SlotTimeRange_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_SlotTimeRange] PRIMARY KEY CLUSTERED ([SlotTimeRangeId] ASC),
	CONSTRAINT [FK_SlotTimeRange_Slot] FOREIGN KEY ([SlotKey]) REFERENCES [Entity].[Slot] ([SlotKey]),
	CONSTRAINT [FK_SlotTimeRange_TimeRange] FOREIGN KEY ([TimeRangeKey]) REFERENCES [Entity].[TimeRange] ([TimeRangeKey]),
    CONSTRAINT [FK_SlotTimeRange_TimeType] FOREIGN KEY ([TimeTypeKey]) REFERENCES [Entity].[TimeType] ([TimeTypeKey]),    
    CONSTRAINT [FK_SlotTimeRange_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE NonCLUSTERED INDEX [IX_SlotTimeRange_Slot] ON [Entity].[SlotTimeRange] ([SlotKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_SlotTime_All] ON [Entity].[SlotTimeRange] ([SlotKey] Asc, [TimeRangeKey] Asc)
GO