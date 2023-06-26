CREATE TABLE [Entity].[EventOption] (
    [EventOptionId]        INT IDENTITY (1, 1) CONSTRAINT [DF_EventOption_EventOptionId] NOT NULL,
    [EventOptionKey]		UNIQUEIDENTIFIER CONSTRAINT [DF_EventOption_EventOptionKey] DEFAULT(NewId()) NOT NULL,
    [EventKey]             UNIQUEIDENTIFIER CONSTRAINT [DF_EventOption_Entity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [OptionKey]             UNIQUEIDENTIFIER CONSTRAINT [DF_EventOption_Option] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_EventOption_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_EventOption_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,    
    CONSTRAINT [PK_EventOption] PRIMARY KEY CLUSTERED ([EventOptionId] ASC),
    CONSTRAINT [FK_EventOption_Event] FOREIGN KEY ([EventKey]) REFERENCES [Entity].[Event] ([EventKey]),
    CONSTRAINT [FK_EventOption_Option] FOREIGN KEY ([OptionKey]) REFERENCES [Entity].[Option] ([OptionKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventOption_All] ON [Entity].[EventOption] ([EventKey] Asc, [OptionKey] Asc)
GO
