Create Procedure [EntityCode].[BusinessInfoSave]
    @Id             	int,
    @Key				uniqueidentifier,
	@Name			    nvarchar(50),
	@TaxNumber			nvarchar(50)
AS
	-- Local variables
	-- Initialize
	Select	@Key		= IsNull(@Key, '00000000-0000-0000-0000-000000000000')
	Select 	@Name		= RTRIM(LTRIM(@Name))
	Select 	@TaxNumber	= RTRIM(LTRIM(@TaxNumber))
	
	-- Validate data that will be inserted/updated, and ensure basic values exist
	If ((@Name <> '') Or (@TaxNumber <> ''))
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull(BusinessKey, @Key) From [Entity].[Business] P Where P.[BusinessId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(BusinessId, -1) From [Entity].[Business] P Where [BusinessKey] = @Key
		-- Insert vs Update		
		Begin Try
			If (@Id Is Null) Or (@Id = -1)
			Begin
				-- Create main entity record		
				Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[Entity] (EntityKey) Values (@Key)
				-- Create Business record
				Insert Into [Entity].[Business] (BusinessKey, BusinessName, TaxNumber, RecordStateKey)
					Values (@Key, @Name, @TaxNumber, '00000000-0000-0000-0000-000000000000')
				Select	@Id = SCOPE_IDENTITY()
			End
			Else
			Begin
				-- Create main entity record
				Update P
				Set P.BusinessName		    = @Name, 
					P.TaxNumber			    = @TaxNumber, 
					P.ModifiedDate			= GetUTCDate()
				From	[Entity].[Business] P
				Where	P.BusinessId = @Id
			End
		End Try
		Begin Catch
			Exec [Activity].[ExceptionLogInsertByException];
		End Catch
	End	

	-- Return data
	Select	IsNull(@Id, -1) As [Id], IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
