Create VIEW [EntityCode].[ResourceType]
	AS 
SELECT	ET.ResourceTypeId As [Id],
		ET.ResourceTypeKey As [Key],
		ET.ResourceTypeName As Name, 
		ET.ResourceTypeDescription As Description, 
		ET.CreatedDate
FROM	[Entity].[ResourceType] ET

