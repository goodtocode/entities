CREATE TABLE [Entity].[LocationTimeRecurring] (
    [LocationTimeRecurringId]   INT IDENTITY (1, 1) CONSTRAINT [DF_LocationTimeRecurring_Id] NOT NULL,
    [LocationTimeRecurringKey]  UNIQUEIDENTIFIER CONSTRAINT [DF_LocationTimeRecurring_Key] DEFAULT(NewId()) NOT NULL,
	[LocationKey]	            UNIQUEIDENTIFIER CONSTRAINT [DF_LocationTimeRecurring_Location] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[TimeRecurringKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_LocationTimeRecurring_TimeRecurring] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DayName]			        NVARCHAR (50)    CONSTRAINT [DF_LocationTimeRecurring_DayName] DEFAULT ('') NOT NULL,
    [TimeName]			        NVARCHAR (50)    CONSTRAINT [DF_LocationTimeRecurring_TimeName] DEFAULT ('') NOT NULL,
    [TimeTypeKey]	        UNIQUEIDENTIFIER    CONSTRAINT [DF_LocationTimeRecurring_TimeType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]            UNIQUEIDENTIFIER  CONSTRAINT [DF_LocationTimeRecurring_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_LocationTimeRecurring_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_LocationTimeRecurring_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_LocationTimeRecurring] PRIMARY KEY CLUSTERED ([LocationTimeRecurringId] ASC),
	CONSTRAINT [FK_LocationTimeRecurring_Location] FOREIGN KEY ([LocationKey]) REFERENCES [Entity].[Location] ([LocationKey]),
	CONSTRAINT [FK_LocationTimeRecurring_TimeRecurring] FOREIGN KEY ([TimeRecurringKey]) REFERENCES [Entity].[TimeRecurring] ([TimeRecurringKey]),
    CONSTRAINT [FK_LocationAvailable_TimeType] FOREIGN KEY ([TimeTypeKey]) REFERENCES [Entity].[TimeType] ([TimeTypeKey]),    
    CONSTRAINT [FK_LocationTimeRecurring_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_LocationTimeRecurring_Key] ON [Entity].[LocationTimeRecurring] ([LocationTimeRecurringKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_LocationTimeRecurring_All] ON [Entity].[LocationTimeRecurring] ([LocationKey] Asc, [TimeRecurringKey] Asc)
GO