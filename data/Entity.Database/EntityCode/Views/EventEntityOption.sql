Create View [EntityCode].[EventEntityOption]
	AS 
Select	CP.EventEntityOptionId As [Id], 
        CP.EventEntityOptionKey As [Key], 
        CP.EventKey,
		CP.EntityKey,
		P.OptionKey,
		P.OptionGroupKey, 
        P.OptionName,
        P.OptionDescription,
        CP.ModifiedDate,
		CP.CreatedDate
From	[Entity].EventEntityOption CP
Join	[Entity].[Option] P	On CP.OptionKey = P.OptionKey
