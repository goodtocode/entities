CREATE TABLE [Entity].[EventEntityOption] (
    [EventEntityOptionId]     INT IDENTITY(1,1) CONSTRAINT [DF_EventEntityOption_Id] NOT NULL,
    [EventEntityOptionKey]    UNIQUEIDENTIFIER CONSTRAINT [DF_EventEntityOption_Key] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [OptionKey]       UNIQUEIDENTIFIER CONSTRAINT [DF_EventEntityOption_Option] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [EventKey]      UNIQUEIDENTIFIER CONSTRAINT [DF_EventEntityOption_Event] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [EntityKey]       UNIQUEIDENTIFIER CONSTRAINT [DF_EventEntityOption_Entity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_EventEntityOption_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_EventEntityOption_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_EventEntityOption] PRIMARY KEY CLUSTERED ([EventEntityOptionId] ASC),
    CONSTRAINT [FK_EventEntityOption_Option] FOREIGN KEY ([OptionKey]) REFERENCES [Entity].[Option] ([OptionKey]),
    CONSTRAINT [FK_EventEntityOption_Event] FOREIGN KEY ([EventKey]) REFERENCES [Entity].[Event] ([EventKey]),
    CONSTRAINT [FK_EventEntityOption_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventEntityOption_Key] ON [Entity].[EventEntityOption] ([EventEntityOptionKey] Asc)
GO