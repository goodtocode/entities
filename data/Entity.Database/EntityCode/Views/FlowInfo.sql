Create View [EntityCode].[FlowInfo]
	AS 
Select	[FlowId] As [Id], 
		[FlowKey] As [Key], 
		[FlowName] as Name, 
		[FlowDescription] As Description, 
		[FlowTypeKey], 
		[ModuleKey], 
		[TimeoutInSeconds], 
		[RecordDeleteInMinutes], 
		[NonRepeatable], 
		[CreatedDate], 
		[ModifiedDate]
From	[Entity].[Flow]
