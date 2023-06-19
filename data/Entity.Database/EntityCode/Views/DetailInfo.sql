Create VIEW [EntityCode].[DetailInfo]
	AS 
SELECT	D.DetailId As [Id],
        D.DetailKey As [Key],
        D.DetailData As [Data],
		DT.DetailTypeName As [Name], 
        DT.DetailTypeDescription As [Description],
        D.DetailTypeKey,
		D.CreatedDate
FROM	[Entity].[Detail] D
    Join [Entity].[DetailType] DT On D.DetailTypeKey = DT.DetailTypeKey
