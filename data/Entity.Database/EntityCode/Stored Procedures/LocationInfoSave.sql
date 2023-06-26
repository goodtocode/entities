Create PROCEDURE [EntityCode].[LocationInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@Name					nvarchar(50),
	@Description			nvarchar(200)
AS
	-- Local variables
	-- Initialize
	Select 	@Name			= RTRIM(LTRIM(@Name))
	Select 	@Description	= RTRIM(LTRIM(@Description))

	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([LocationKey], @Key) From [Entity].[Location] Where [LocationId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([LocationId], -1) From [Entity].[Location] Where [LocationKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[Location] (LocationKey, LocationName, LocationDescription, RecordStateKey)
			Values (@Key, @Name, @Description, '00000000-0000-0000-0000-000000000000')
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- Location master
		Update [Entity].[Location]
		Set	LocationName			= @Name,
			LocationDescription	    = @Description,
				
			ModifiedDate		= GetUTCDate()
		Where	LocationId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
