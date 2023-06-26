Create VIEW [EntityCode].[DetailType]
	AS 
SELECT	DT.DetailTypeId As [Id],
        DT.DetailTypeKey As [Key],
		DT.DetailTypeName As [Name],
		DT.DetailTypeDescription As [Description], 
		DT.CreatedDate
FROM	[Entity].[DetailType] DT
