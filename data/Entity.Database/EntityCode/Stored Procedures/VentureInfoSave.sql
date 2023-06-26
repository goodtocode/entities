Create PROCEDURE [EntityCode].[VentureInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@VentureGroupKey		Uniqueidentifier,
	@VentureTypeKey			Uniqueidentifier,
	@Name					nvarchar(50),
	@Description			nvarchar(200),
	@Slogan					nvarchar(50)
AS
	-- Local variables
	-- Initialize
	Select 	@Name			= RTRIM(LTRIM(@Name))
	Select 	@Description	= RTRIM(LTRIM(@Description))
	Select 	@Slogan			= RTRIM(LTRIM(@Slogan))

	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([VentureKey], @Key) From [Entity].[Venture] Where [VentureId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureId], -1) From [Entity].[Venture] Where [VentureKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[Venture] (VentureKey, VentureGroupKey, VentureTypeKey, VentureName, VentureDescription, VentureSlogan, RecordStateKey)
			Values (@Key, @VentureGroupKey, @VentureTypeKey, @Name, @Description, @Slogan, '00000000-0000-0000-0000-000000000000')
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- Venture master
		Update [Entity].[Venture]
		Set	VentureName			= @Name,
			VentureDescription	= @Description,
			VentureSlogan			= @Slogan,
			VentureTypeKey		= @VentureTypeKey,
				
			ModifiedDate		= GetUTCDate()
		Where	VentureId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
