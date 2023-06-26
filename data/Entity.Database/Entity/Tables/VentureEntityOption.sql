CREATE TABLE [Entity].[VentureEntityOption] (
    [VentureEntityOptionId]     INT IDENTITY(1,1) CONSTRAINT [DF_VentureEntityOption_Id] NOT NULL,
    [VentureEntityOptionKey]    UNIQUEIDENTIFIER CONSTRAINT [DF_VentureEntityOption_Key] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [OptionKey]       UNIQUEIDENTIFIER CONSTRAINT [DF_VentureEntityOption_Option] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [VentureKey]      UNIQUEIDENTIFIER CONSTRAINT [DF_VentureEntityOption_Venture] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [EntityKey]       UNIQUEIDENTIFIER CONSTRAINT [DF_VentureEntityOption_Entity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_VentureEntityOption_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_VentureEntityOption_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_VentureEntityOption] PRIMARY KEY CLUSTERED ([VentureEntityOptionId] ASC),
    CONSTRAINT [FK_VentureEntityOption_Option] FOREIGN KEY ([OptionKey]) REFERENCES [Entity].[Option] ([OptionKey]),
    CONSTRAINT [FK_VentureEntityOption_Venture] FOREIGN KEY ([VentureKey]) REFERENCES [Entity].[Venture] ([VentureKey]),
    CONSTRAINT [FK_VentureEntityOption_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureEntityOption_Key] ON [Entity].[VentureEntityOption] ([VentureEntityOptionKey] Asc)
GO