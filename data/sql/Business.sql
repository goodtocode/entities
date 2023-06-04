IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Subjects].[Business]') AND type in (N'U'))
DROP TABLE [Subjects].[Business]
GO
