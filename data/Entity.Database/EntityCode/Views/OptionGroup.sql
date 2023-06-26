Create View [EntityCode].[OptionGroup]
AS 
Select	PG.OptionGroupId As [Id], 
		PG.OptionGroupKey As [Key],
		PG.OptionGroupName As Name, 
		PG.OptionGroupDescription As Description, 
		PG.CreatedDate,
		PG.ModifiedDate
From	[Entity].OptionGroup PG
