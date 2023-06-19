Create View [EntityCode].[EventOption]
	AS 
Select	CP.EventOptionId As [Id], 
        CP.EventOptionKey As [Key], 
		CP.EventKey,
		P.OptionKey,
		P.OptionGroupKey, 
        P.OptionName,
        P.OptionDescription,
        CP.ModifiedDate,
		CP.CreatedDate
From	[Entity].EventOption CP
Join	[Entity].[Option] P	On CP.OptionKey = P.OptionKey
