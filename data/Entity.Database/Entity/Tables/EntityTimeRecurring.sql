CREATE TABLE [Entity].[EntityTimeRecurring] (
    [EntityTimeRecurringId]     INT IDENTITY (1, 1) CONSTRAINT [DF_EntityTimeRecurring_EntityTimeRecurringId] NOT NULL,
    [EntityTimeRecurringKey]    UNIQUEIDENTIFIER CONSTRAINT [DF_EntityTimeRecurring_EntityTimeRecurringKey] DEFAULT(NewId()) NOT NULL,
	[EntityKey]	                UNIQUEIDENTIFIER CONSTRAINT [DF_EntityTimeRecurring_EntityId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[TimeRecurringKey]	        UNIQUEIDENTIFIER CONSTRAINT [DF_EntityTimeRecurring_TimeRecurringId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DayName]			        NVARCHAR (50)    CONSTRAINT [DF_EntityTimeRecurring_DayName] DEFAULT ('') NOT NULL,
    [TimeName]			        NVARCHAR (50)    CONSTRAINT [DF_EntityTimeRecurring_TimeName] DEFAULT ('') NOT NULL,
    [TimeTypeKey]	            UNIQUEIDENTIFIER    CONSTRAINT [DF_EntityTimeRecurring_TimeType] DEFAULT('00000000-0000-0000-0000-000000000000') NULL,
    [RecordStateKey]            UNIQUEIDENTIFIER  CONSTRAINT [DF_EntityTimeRecurring_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_EntityTimeRecurring_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_EntityTimeRecurring_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EntityTimeRecurring] PRIMARY KEY CLUSTERED ([EntityTimeRecurringId] ASC),
	CONSTRAINT [FK_EntityTimeRecurring_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
	CONSTRAINT [FK_EntityTimeRecurring_TimeRecurring] FOREIGN KEY ([TimeRecurringKey]) REFERENCES [Entity].[TimeRecurring] ([TimeRecurringKey]),
    CONSTRAINT [FK_EntityAvailable_TimeType] FOREIGN KEY ([TimeTypeKey]) REFERENCES [Entity].[TimeType] ([TimeTypeKey]),    
    CONSTRAINT [FK_EntityTimeRecurring_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityTimeRecurring_Key] ON [Entity].[EntityTimeRecurring] ([EntityTimeRecurringKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityTimeRecurring_All] ON [Entity].[EntityTimeRecurring] ([EntityKey] Asc, [TimeRecurringKey] Asc)
GO