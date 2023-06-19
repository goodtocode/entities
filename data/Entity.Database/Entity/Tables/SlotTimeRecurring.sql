CREATE TABLE [Entity].[SlotTimeRecurring] (
    [SlotTimeRecurringId]   INT IDENTITY (1, 1) CONSTRAINT [DF_SlotTimeRecurring_SlotTimeRecurringId] NOT NULL,
    [SlotTimeRecurringKey]  UNIQUEIDENTIFIER CONSTRAINT [DF_Application_SlotTimeRecurringKey] DEFAULT (NewId()) NOT NULL,
	[SlotKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotTimeRecurring_SlotId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[TimeRecurringKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotTimeRecurring_TimeRecurringId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [TimeTypeKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_SlotTimeRecurring_TimeType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_SlotTimeRecurring_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_SlotTimeRecurring_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_SlotTimeRecurring_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_SlotTimeRecurring] PRIMARY KEY CLUSTERED ([SlotTimeRecurringId] ASC),
	CONSTRAINT [FK_SlotTimeRecurring_Slot] FOREIGN KEY ([SlotKey]) REFERENCES [Entity].[Slot] ([SlotKey]),
	CONSTRAINT [FK_SlotTimeRecurring_TimeRecurring] FOREIGN KEY ([TimeRecurringKey]) REFERENCES [Entity].[TimeRecurring] ([TimeRecurringKey]),
    CONSTRAINT [FK_SlotTimeRecurring_TimeType] FOREIGN KEY ([TimeTypeKey]) REFERENCES [Entity].[TimeType] ([TimeTypeKey]),    
    CONSTRAINT [FK_SlotTimeRecurring_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE NonCLUSTERED INDEX [IX_SlotTimeRecurring_Slot] ON [Entity].[SlotTimeRecurring] ([SlotKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_SlotTime_All] ON [Entity].[SlotTimeRecurring] ([SlotKey] Asc, [TimeRecurringKey] Asc)
GO