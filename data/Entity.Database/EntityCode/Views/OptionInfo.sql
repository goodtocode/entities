Create View [EntityCode].[OptionInfo]
	AS 
SELECT  O.OptionId As [Id],
		O.OptionKey As [Key],
		O.OptionGroupKey,
		O.OptionName As Name,
		O.OptionDescription As Description, 
		O.OptionCode As Code,
		(OG.OptionGroupName + '-' + O.OptionName) As FullName, 
		(OG.OptionGroupCode + '-' + O.OptionCode) As FullCode, 
		O.SortOrder,
        O.CreatedDate,
        O.ModifiedDate
From	[Entity].[Option] O
Join    [Entity].[OptionGroup] OG On O.OptionGroupKey = OG.OptionGroupKey
