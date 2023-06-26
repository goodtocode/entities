Create VIEW [EntityCode].[LocationType]
	AS 
SELECT	ET.LocationTypeId As [Id],
		ET.LocationTypeKey As [Key],
		ET.LocationTypeName As Name, 
		ET.LocationTypeDescription As Description, 
		ET.CreatedDate
FROM	[Entity].[LocationType] ET

