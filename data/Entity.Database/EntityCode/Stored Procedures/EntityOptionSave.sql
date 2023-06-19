Create PROCEDURE [EntityCode].[EntityOptionSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @EntityKey			    Uniqueidentifier,
    @OptionKey			    Uniqueidentifier
AS
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([EntityOptionKey], @Key) From [Entity].[EntityOption] Where [EntityOptionId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EntityOptionId], -1) From [Entity].[EntityOption] Where [EntityOptionKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[EntityOption] (EntityOptionKey, EntityKey, OptionKey)
			Values (@Key, @EntityKey, @OptionKey)
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- EntityOption master
		Update [Entity].[EntityOption]
		Set	OptionKey          = @OptionKey,			
			ModifiedDate		= GetUTCDate()
		Where	EntityOptionId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
