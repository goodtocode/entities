CREATE TABLE [Entity].[EntityDetail] (
    [EntityDetailId]             INT IDENTITY (1, 1) CONSTRAINT [DF_EntityDetail_Id] NOT NULL,
    [EntityDetailKey]            UNIQUEIDENTIFIER CONSTRAINT [DF_EntityDetail_Key] DEFAULT (NewID()) NOT NULL,
    [EntityKey]                  UNIQUEIDENTIFIER CONSTRAINT [DF_EntityDetail_Entity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DetailKey]                 UNIQUEIDENTIFIER CONSTRAINT [DF_EntityDetail_Detail] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_EntityDetail_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_EntityDetail_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EntityDetail] PRIMARY KEY CLUSTERED ([EntityDetailId] ASC),
    CONSTRAINT [FK_EntityDetail_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_EntityDetail_Detail] FOREIGN KEY ([DetailKey]) REFERENCES [Entity].[Detail] ([DetailKey]),
    CONSTRAINT [UQ_EntityDetail_EntityDetailId] UNIQUE NONCLUSTERED ([EntityKey] ASC, [EntityDetailKey] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityDetail_Key] ON [Entity].[EntityDetail] ([EntityDetailKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EntityDetail_All] ON [Entity].[EntityDetail] ([EntityKey] Asc, [EntityDetailKey] Asc)
