CREATE TABLE [Entity].[TimeType] (
    [TimeTypeId]           INT IDENTITY (1, 1) CONSTRAINT [DF_TimeType_TimeTypeId] NOT NULL,
	[TimeTypeKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_TimeType_TimeTypeKey] DEFAULT (NewID()) NOT NULL,
    [TimeTypeName]          NVARCHAR (50)    CONSTRAINT [DF_TimeType_TimeTypeName] DEFAULT ('') NOT NULL,
    [TimeTypeDescription]   NVARCHAR (250)   CONSTRAINT [DF_TimeType_TimeTypeDescription] DEFAULT ('') NOT NULL,
    [TimeBehavior]          INT              CONSTRAINT [DF_TimeType_TimeBehavior] DEFAULT (1) NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_TimeType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_TimeType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_TimeType] PRIMARY KEY CLUSTERED ([TimeTypeId] ASC),
    CONSTRAINT [CC_TimeType_TimeBehavior] CHECK ([TimeBehavior] BETWEEN -1 AND 1)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_TimeType_Key] ON [Entity].[TimeType] ([TimeTypeKey] Asc)
GO