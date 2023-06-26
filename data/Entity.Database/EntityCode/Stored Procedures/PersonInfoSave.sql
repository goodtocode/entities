Create Procedure [EntityCode].[PersonInfoSave]
    @Id             	int,
    @Key				uniqueidentifier,
	@FirstName			nvarchar(50),
	@MiddleName			nvarchar(50),
	@LastName			nvarchar(50),
	@BirthDate			datetime,
	@GenderCode			nvarchar(10)
AS
	-- Local variables
	Declare @EntityId As Int = -1
	Declare @GenderId as Int = -1
	-- Initialize
    Select	@Id			    = IsNull(@Id, -1)
	Select	@Key			= IsNull(@Key, '00000000-0000-0000-0000-000000000000')
	Select 	@FirstName		= RTRIM(LTRIM(@FirstName))
	Select 	@MiddleName		= RTRIM(LTRIM(@MiddleName))
	Select 	@LastName		= RTRIM(LTRIM(@LastName))
	
	-- Validate data that will be inserted/updated, and ensure basic values exist
	If ((@FirstName <> '') Or (@MiddleName <> '') Or (@LastName <> ''))
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull(PersonKey, @Key) From [Entity].[Person] P Where [PersonId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(PersonId, -1) From [Entity].[Person] P Where [PersonKey] = @Key
		-- Get extra data
		Select @GenderId = IsNull(GenderId, -1) From [Entity].[Gender] Where GenderCode = @GenderCode
		-- Insert vs Update		
		Begin Try			
			If (@Id Is Null) Or (@Id = -1)
			Begin
				-- Create main entity record		
				Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[Entity] (EntityKey) 
                    Values (@Key)
				Select	@EntityId = SCOPE_IDENTITY()
				-- Create person record
				Insert Into [Entity].[Person] (PersonKey, FirstName, MiddleName, LastName, BirthDate, GenderId, RecordStateKey)
					Values (@Key, @FirstName, @MiddleName, @LastName, @BirthDate, @GenderId, '00000000-0000-0000-0000-000000000000')
				Select	@Id = SCOPE_IDENTITY()
			End
			Else
			Begin
				-- Create main entity record
				Update P
				Set P.FirstName				= @FirstName, 
					P.MiddleName			= @MiddleName, 
					P.LastName				= @LastName, 
					P.BirthDate				= @BirthDate, 
					P.GenderId				= @GenderId,
					P.ModifiedDate			= GetUTCDate()
				From	[Entity].[Person] P
				Where	P.PersonId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
	End	

	-- Return data
	Select	IsNull(@Id, -1) As [Id], IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
