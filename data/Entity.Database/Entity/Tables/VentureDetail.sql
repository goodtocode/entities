CREATE TABLE [Entity].[VentureDetail] (
    [VentureDetailId]             INT IDENTITY (1, 1) CONSTRAINT [DF_VentureDetail_Id] NOT NULL,
    [VentureDetailKey]            UNIQUEIDENTIFIER CONSTRAINT [DF_VentureDetail_Key] DEFAULT (NewID()) NOT NULL,
    [VentureKey]                  UNIQUEIDENTIFIER CONSTRAINT [DF_VentureDetail_Venture] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DetailKey]                 UNIQUEIDENTIFIER CONSTRAINT [DF_VentureDetail_Detail] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_VentureDetail_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_VentureDetail_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_VentureDetail] PRIMARY KEY CLUSTERED ([VentureDetailId] ASC),
    CONSTRAINT [FK_VentureDetail_Venture] FOREIGN KEY ([VentureKey]) REFERENCES [Entity].[Venture] ([VentureKey]),
    CONSTRAINT [FK_VentureDetail_Detail] FOREIGN KEY ([DetailKey]) REFERENCES [Entity].[Detail] ([DetailKey]),
    CONSTRAINT [UQ_VentureDetail_VentureDetailId] UNIQUE NONCLUSTERED ([VentureKey] ASC, [VentureDetailKey] ASC)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureDetail_Key] ON [Entity].[VentureDetail] ([VentureDetailKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureDetail_All] ON [Entity].[VentureDetail] ([VentureKey] Asc, [VentureDetailKey] Asc)
