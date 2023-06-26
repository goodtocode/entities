Create VIEW [EntityCode].[EventType]
	AS 
SELECT	ET.EventTypeId As [Id],
		ET.EventTypeKey As [Key],
		ET.EventTypeName As Name, 
		ET.EventTypeDescription As Description, 
		ET.CreatedDate, 
		ET.EventGroupKey
FROM	[Entity].[EventType] ET

