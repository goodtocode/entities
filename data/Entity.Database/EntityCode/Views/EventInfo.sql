Create VIEW [EntityCode].[EventInfo]
AS 
	Select	E.EventId As [Id], 
			E.EventKey As [Key],
			E.EventGroupKey,
			E.EventTypeKey,
			E.EventCreatorKey,
			E.EventName As Name, 
			E.EventDescription As [Description], 
			E.EventSlogan As Slogan, 
			E.CreatedDate, 
			E.ModifiedDate
	From	[Entity].[Event] E
    Where   E.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'

