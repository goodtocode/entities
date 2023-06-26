Create VIEW [EntityCode].[ScheduleType]
	AS 
SELECT	ET.ScheduleTypeId As [Id],
		ET.ScheduleTypeKey As [Key],
		ET.ScheduleTypeName As Name, 
		ET.ScheduleTypeDescription As Description, 
		ET.CreatedDate
FROM	[Entity].[ScheduleType] ET

