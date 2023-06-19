Create Procedure [EntityCode].[GovernmentInfoSave]
    @Id             	int,
    @Key				uniqueidentifier,
	@Name			    nvarchar(50)
AS
	-- Initialize
	Select 	@Name		= RTRIM(LTRIM(@Name))
	
	-- Validate data that will be inserted/updated, and ensure basic values exist
	If (@Name <> '')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull(GovernmentKey, @Key) From [Entity].[Government] P Where P.[GovernmentId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(GovernmentId, -1) From [Entity].[Government] P Where [GovernmentKey] = @Key
		-- Insert vs Update
		
		Begin Try
			If (@Id Is Null) Or (@Id = -1)
			Begin
				-- Create main entity record		
				Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[Entity] (EntityKey) Values (@Key)
				-- Create Government record
				Insert Into [Entity].[Government] (GovernmentKey, GovernmentName, RecordStateKey)
					Values (@Key, @Name, '00000000-0000-0000-0000-000000000000')	
				Select	@Id = SCOPE_IDENTITY()
			End
			Else
			Begin
				-- Create main entity record
				Update P
				Set P.GovernmentName		= @Name, 
					P.ModifiedDate			= GetUTCDate()
				From	[Entity].[Government] P
				Where	P.GovernmentId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
	End	

	-- Return data
	Select	IsNull(@Id, -1) As [Id], IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
