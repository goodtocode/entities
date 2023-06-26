Create PROCEDURE [EntityCode].[EventOptionSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @EventKey			    Uniqueidentifier,
    @OptionKey			    Uniqueidentifier
AS
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([EventOptionKey], @Key) From [Entity].[EventOption] Where [EventOptionId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventOptionId], -1) From [Entity].[EventOption] Where [EventOptionKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[EventOption] (EventOptionKey, EventKey, OptionKey)
			Values (@Key, @EventKey, @OptionKey)
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- EventOption master
		Update [Entity].[EventOption]
		Set	    OptionKey          = @OptionKey,
				    
				ModifiedDate		= GetUTCDate()
		Where	EventOptionId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
