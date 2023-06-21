-- Messages
Select	M.FromEntityID, M.MessageSubject As Subject, M.MessageBody As Body, M.CreatedDate, M.ModifiedDate, M.WorkflowStepID, MM.*, MP.*, MB.*
From	[EntityData].[Entity].Message M 
Left Join	[EntityData].Active.MessageEvent MM On M.MessageID = MM.MessageID
Left Join	[EntityData].Active.MessagePerson MP On M.MessageID = MP.MessageID
Left Join	[EntityData].Active.MessageBusiness MB On M.MessageID = MB.MessageID


Select	MM.MessageEventID As ID, M.ParentMessageID, MM.EventID, M.FromEntityID, M.MessageSubject As Subject, M.MessageBody As Body, M.CreatedDate, M.ModifiedDate, M.WorkflowStepID
From	[EntityData].Active.MessageEvent MM
Join	[EntityData].[Entity].Message M On MM.MessageID = M.MessageID

Select --
From	EntityData200.[Entity].MessageTable

-- Template Types
Use EntityData
Select	TT.TemplateTypeID, TT.TemplateTypeName, TT.FieldCount, T.TemplateID, T.TemplateName, T.TemplateHTML
From	[EntityData].[Entity].TemplateType TT
Left Join [EntityData].[Entity].Template T On TT.TemplateTypeID = T.TemplateTypeID
Order By TemplateTypeName, TemplateName

-- Templates
Use EntityData
Select	Tt.TemplateTypeID, TT.TemplateTypeName, T.TemplateID, T.TemplateName, T.TemplateHTML
From	[EntityData].[Entity].Template T
Left Join [EntityData].[Entity].TemplateType TT On T.TemplateTypeID = TT.TemplateTypeID
Order By TT.TemplateTypeName, T.TemplateName

-- EXEC [EntityData].DBA.TemplateHTMLUpdate '7CE4F76F-E705-49B0-A954-4DF69431586D', 'c:\backup\uploads\Reply.html'
-- EXEC [EntityData].DBA.TemplateImageUpdate '8C01F7EE-15D0-45D8-A82C-838E7F8C81C8', 'c:\backup\uploads\picnic.jpg'

--INSERT [EntityData].[Entity].[Template] ([TemplateID], [TemplateTypeID], [TemplateName], [TemplateDescription]) Values (NewID(), '19CC0F01-E1C7-4EC9-B1B6-F7E11742EC50', 'Reply Message', 'Reply to any message sent to you.')

