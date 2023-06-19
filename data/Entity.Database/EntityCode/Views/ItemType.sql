Create VIEW [EntityCode].[ItemType]
	AS 
SELECT	ET.ItemTypeId As [Id],
		ET.ItemTypeKey As [Key],
		ET.ItemTypeName As Name, 
		ET.ItemTypeDescription As Description, 
		ET.CreatedDate, 
		ET.ItemGroupKey
FROM	[Entity].[ItemType] ET

