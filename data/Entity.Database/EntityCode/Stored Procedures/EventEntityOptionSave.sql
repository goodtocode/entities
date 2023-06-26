Create PROCEDURE [EntityCode].[EventEntityOptionSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @EventKey			    Uniqueidentifier,
    @EntityKey			    Uniqueidentifier,
    @OptionKey			    Uniqueidentifier
AS
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([EventEntityOptionKey], @Key) From [Entity].[EventEntityOption] Where [EventEntityOptionId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventEntityOptionId], -1) From [Entity].[EventEntityOption] Where [EventEntityOptionKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[EventEntityOption] (EventEntityOptionKey, EventKey, EntityKey, OptionKey)
			Values (@Key, @EventKey, @EntityKey, @OptionKey)
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- EventEntityOption master
		Update [Entity].[EventEntityOption]
		Set	    OptionKey           = @OptionKey,
				    
				ModifiedDate		= GetUTCDate()
		Where	EventEntityOptionId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
