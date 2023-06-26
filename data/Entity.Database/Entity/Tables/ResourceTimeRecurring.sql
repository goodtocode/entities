CREATE TABLE [Entity].[ResourceTimeRecurring] (
    [ResourceTimeRecurringId]   INT IDENTITY (1, 1) CONSTRAINT [DF_ResourceTimeRecurring_ResourceTimeRecurringId] NOT NULL,
    [ResourceTimeRecurringKey]  UNIQUEIDENTIFIER CONSTRAINT [DF_ResourceTimeRecurring_ResourceTimeRecurringKey] DEFAULT(NewId()) NOT NULL,
	[ResourceKey]	            UNIQUEIDENTIFIER CONSTRAINT [DF_ResourceTimeRecurring_Resource] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[TimeRecurringKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_ResourceTimeRecurring_TimeRecurring] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DayName]			        NVARCHAR (50)    CONSTRAINT [DF_ResourceTimeRecurring_DayName] DEFAULT ('') NOT NULL,
    [TimeName]			        NVARCHAR (50)    CONSTRAINT [DF_ResourceTimeRecurring_TimeName] DEFAULT ('') NOT NULL,
    [TimeTypeKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_ResourceTimeRecurring_TimeType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]            UNIQUEIDENTIFIER  CONSTRAINT [DF_ResourceTimeRecurring_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_ResourceTimeRecurring_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_ResourceTimeRecurring_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ResourceTimeRecurring] PRIMARY KEY CLUSTERED ([ResourceTimeRecurringId] ASC),
	CONSTRAINT [FK_ResourceTimeRecurring_Resource] FOREIGN KEY ([ResourceKey]) REFERENCES [Entity].[Resource] ([ResourceKey]),
	CONSTRAINT [FK_ResourceTimeRecurring_TimeRecurring] FOREIGN KEY ([TimeRecurringKey]) REFERENCES [Entity].[TimeRecurring] ([TimeRecurringKey]),
    CONSTRAINT [FK_ResourceTimeRecurring_TimeType] FOREIGN KEY ([TimeTypeKey]) REFERENCES [Entity].[TimeType] ([TimeTypeKey]),   
    CONSTRAINT [FK_ResourceTimeRecurring_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ResourceTimeRecurring_Resource] ON [Entity].[ResourceTimeRecurring] ([ResourceTimeRecurringKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ResourceTimeRecurring_Resource] ON [Entity].[SlotResource] ([ResourceKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ResourceTimeRecurring_All] ON [Entity].[ResourceTimeRecurring] ([ResourceKey] Asc, [TimeRecurringKey] Asc)
GO