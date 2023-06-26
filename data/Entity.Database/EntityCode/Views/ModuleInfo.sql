CREATE View [EntityCode].[ModuleInfo]
AS 
	Select	M.ModuleId As [Id], 
			M.ModuleKey As [Key],
			M.ModuleName As Name, 
			M.ModuleDescription As Description, 
			M.CreatedDate,
			M.ModifiedDate
	From	[Entity].[Module] M
