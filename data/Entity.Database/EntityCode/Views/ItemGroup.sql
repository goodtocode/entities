Create VIEW [EntityCode].[ItemGroup]
	AS 
SELECT	ET.ItemGroupId As [Id],
		ET.ItemGroupKey As [Key],
		ET.ItemGroupName As Name, 
		ET.ItemGroupDescription As Description, 
		ET.CreatedDate, 
		ET.ItemGroupKey
FROM	[Entity].[ItemGroup] ET

