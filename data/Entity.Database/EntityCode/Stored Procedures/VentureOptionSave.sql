Create PROCEDURE [EntityCode].[VentureOptionSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @VentureKey			    Uniqueidentifier,
    @OptionKey			    Uniqueidentifier
AS
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([VentureOptionKey], @Key) From [Entity].[VentureOption] Where [VentureOptionId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureOptionId], -1) From [Entity].[VentureOption] Where [VentureOptionKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[VentureOption] (VentureOptionKey, VentureKey, OptionKey)
			Values (@Key, @VentureKey, @OptionKey)
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- VentureOption master
		Update [Entity].[VentureOption]
		Set	    OptionKey          = @OptionKey,
				    
				ModifiedDate		= GetUTCDate()
		Where	VentureOptionId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
