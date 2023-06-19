CREATE TABLE [Entity].[Gender] (
    [GenderId]				INT CONSTRAINT [DF_Gender_GenderId] NOT NULL,
	[GenderKey]				UNIQUEIDENTIFIER CONSTRAINT [DF_Gender_GenderKey] DEFAULT(NewId()) NOT NULL,
	[GenderName]			NVARCHAR (50)    CONSTRAINT [DF_Gender_GenderName] DEFAULT ('') NOT NULL,
	[GenderCode]			NVARCHAR(10)             CONSTRAINT [DF_Gender_GenderCode] DEFAULT ('') NOT NULL,
    [CreatedDate]			DATETIME    CONSTRAINT [DF_Gender_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]			DATETIME    CONSTRAINT [DF_Gender_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED ([GenderId] ASC),
	CONSTRAINT [CC_Gender_Id] CHECK ([GenderId] BETWEEN -1 AND 9)
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Gender_Key] ON [Entity].[Gender] ([GenderKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Gender_Code] ON [Entity].[Gender] ([GenderCode] Asc)
GO