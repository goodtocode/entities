Create VIEW [EntityCode].[TimeType]
	AS 
SELECT	ET.TimeTypeId As [Id],
		ET.TimeTypeKey As [Key],
		ET.TimeTypeName As [Name], 
        ET.TimeBehavior As [TimeBehavior], 
		ET.TimeTypeDescription As Description, 
		ET.CreatedDate
FROM	[Entity].[TimeType] ET

