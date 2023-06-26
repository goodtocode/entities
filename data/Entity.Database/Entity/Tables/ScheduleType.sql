CREATE TABLE [Entity].[ScheduleType] (
    [ScheduleTypeId]           INT IDENTITY (1, 1) CONSTRAINT [DF_ScheduleType_ScheduleTypeId] NOT NULL,
	[ScheduleTypeKey]		    UNIQUEIDENTIFIER CONSTRAINT [DC_ScheduleType_ScheduleTypeKey] DEFAULT (NewID()) NOT NULL,
    [ScheduleTypeName]         NVARCHAR (50)    CONSTRAINT [DF_ScheduleType_ScheduleTypeName] DEFAULT ('') NOT NULL,
    [ScheduleTypeDescription]  NVARCHAR (250)   CONSTRAINT [DF_ScheduleType_ScheduleTypeDescription] DEFAULT ('') NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_ScheduleType_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
	[ModifiedDate]			DATETIME         CONSTRAINT [DF_ScheduleType_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ScheduleType] PRIMARY KEY CLUSTERED ([ScheduleTypeId] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ScheduleType_Key] ON [Entity].[ScheduleType] ([ScheduleTypeKey] Asc)
GO