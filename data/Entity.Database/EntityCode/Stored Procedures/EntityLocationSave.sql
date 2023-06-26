Create PROCEDURE [EntityCode].[EntityLocationSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@EntityKey			    Uniqueidentifier,
    @LocationKey			Uniqueidentifier,
    @LocationTypeKey		Uniqueidentifier = null
AS   
	-- Initialize
    Select  @LocationTypeKey        = NullIf(@LocationTypeKey, '00000000-0000-0000-0000-000000000000')
	-- Validate Data
	If  (@EntityKey <> '00000000-0000-0000-0000-000000000000' AND @LocationKey <> '00000000-0000-0000-0000-000000000000')
	Begin       
		-- Id and Key are both valid. Sync now.
		Select Top 1 @Id = IsNull([EntityLocationId], -1), @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), [EntityLocationKey]) 
            From [Entity].[EntityLocation] Where [EntityKey] = @EntityKey AND [LocationKey] = @LocationKey
		-- EntityLocation
		If (@Id Is Null) Or (@Id = -1)
		Begin
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[EntityLocation] (EntityLocationKey, EntityKey, LocationKey, LocationTypeKey, RecordStateKey) 
                Values (@Key, @EntityKey, @LocationKey, @LocationTypeKey, '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
