Create View [EntityCode].[EntityOption]
	AS 
Select	CP.EntityOptionId As [Id], 
        CP.EntityOptionKey As [Key], 
		CP.EntityKey,
		P.OptionKey,
		P.OptionGroupKey, 
        P.OptionName,
        P.OptionDescription,
        CP.ModifiedDate,
		CP.CreatedDate
From	[Entity].EntityOption CP
Join	[Entity].[Option] P	On CP.OptionKey = P.OptionKey
