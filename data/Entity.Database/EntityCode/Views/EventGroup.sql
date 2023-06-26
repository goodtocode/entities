Create VIEW [EntityCode].[EventGroup]
	AS 
SELECT	ET.EventGroupId As [Id],
		ET.EventGroupKey As [Key],
		ET.EventGroupName As Name, 
		ET.EventGroupDescription As Description, 
		ET.CreatedDate, 
		ET.EventGroupKey
FROM	[Entity].[EventGroup] ET

