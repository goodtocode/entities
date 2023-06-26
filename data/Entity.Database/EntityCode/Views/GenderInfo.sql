Create View [EntityCode].[GenderInfo]
	AS 
Select	[GenderId] As [Id], 
		[GenderKey] As [Key], 
		[GenderName] as Name, 
		[GenderCode] As Code, 
		[CreatedDate], 
		[ModifiedDate]
From	[Entity].[Gender]
