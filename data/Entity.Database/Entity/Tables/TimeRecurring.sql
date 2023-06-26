CREATE TABLE [Entity].[TimeRecurring] (
    [TimeRecurringId]       INT IDENTITY (1, 1) CONSTRAINT [DF_TimeRecurring_TimeRecurringId] NOT NULL,
    [TimeRecurringKey]      UNIQUEIDENTIFIER    CONSTRAINT [DF_TimeRecurring_TimeRecurringKey] DEFAULT ('00000000-0000-0000-0000-000000000000') NOT NULL,    
    [BeginDay]	            INT                 CONSTRAINT [DF_TimeRecurring_BeginDate] DEFAULT (-1) NOT NULL,
	[EndDay]	            INT                 CONSTRAINT [DF_TimeRecurring_EndDate] DEFAULT (-1) NOT NULL,
	[BeginTime]	            DATETIME            CONSTRAINT [DF_TimeRecurring_BeginTime] DEFAULT ('01/01/1900') NOT NULL,
	[EndTime]	            DATETIME            CONSTRAINT [DF_TimeRecurring_EndTime] DEFAULT ('01/01/1900') NOT NULL,
    [Interval]	            INT                 CONSTRAINT [DF_TimeRecurring_Interval] DEFAULT (1) NOT NULL,
    [TimeCycleKey]	        UNIQUEIDENTIFIER    CONSTRAINT [DF_TimeRecurring_TimeCycle] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME            CONSTRAINT [DF_TimeRecurring_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_TimeRecurring] PRIMARY KEY CLUSTERED ([TimeRecurringId] ASC),
    CONSTRAINT [FK_TimeRecurring_TimeCycle] FOREIGN KEY ([TimeCycleKey]) REFERENCES [Entity].[TimeCycle] ([TimeCycleKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_TimeRecurring_All] ON [Entity].[TimeRecurring] 
    ([BeginDay] Asc, [EndDay] Asc, [BeginTime] Asc, [EndTime] Asc, [Interval] Asc, [TimeCycleKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_TimeRecurring_TimeRecurringKey] ON [Entity].[TimeRecurring] ([TimeRecurringKey] Asc)
GO