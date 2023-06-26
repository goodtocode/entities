CREATE TABLE [Entity].[TimeCycle] (
    [TimeCycleId]           INT IDENTITY (1, 1) CONSTRAINT [DF_TimeCycle_TimeCycleId] NOT NULL,
	[TimeCycleKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_TimeCycle_TimeCycleKey] DEFAULT (NewID()) NOT NULL,
    [TimeCycleName]         NVARCHAR (50)    CONSTRAINT [DF_TimeCycle_TimeCycleName] DEFAULT ('') NOT NULL,
    [TimeCycleDescription]  NVARCHAR (250)   CONSTRAINT [DF_TimeCycle_TimeCycleDescription] DEFAULT ('') NOT NULL,
    [Days]	                INT              CONSTRAINT [DF_TimeCycle_Days] DEFAULT (-1) NOT NULL,
    [Interval]	            INT              CONSTRAINT [DF_TimeCycle_Interval] DEFAULT (-1) NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_TimeCycle_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_TimeCycle_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_TimeCycle] PRIMARY KEY CLUSTERED ([TimeCycleId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_TimeCycle_Key] ON [Entity].[TimeCycle] ([TimeCycleKey] Asc)
GO