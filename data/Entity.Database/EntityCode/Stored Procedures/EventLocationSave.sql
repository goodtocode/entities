Create PROCEDURE [EntityCode].[EventLocationSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@EventKey			    Uniqueidentifier,
	@EventName			    nvarchar(50),
	@EventDescription	    nvarchar(2000),	
    @LocationKey			Uniqueidentifier,
	@LocationName			nvarchar(50),
	@LocationDescription	nvarchar(2000),	
    @LocationTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@LocationName			= RTRIM(LTRIM(@LocationName))
	Select 	@LocationDescription	= RTRIM(LTRIM(@LocationDescription))
	-- Validate Data
	If  (@EventKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([EventLocationKey], @Key), @LocationKey = IsNull(NullIf(@LocationKey, '00000000-0000-0000-0000-000000000000'), LocationKey), 
            @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), EventKey) From [Entity].[EventLocation] Where [EventLocationId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventLocationId], -1), @LocationKey = IsNull(NullIf(@LocationKey, '00000000-0000-0000-0000-000000000000'), LocationKey), @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), EventKey) From [Entity].[EventLocation] Where [EventLocationKey] = @Key
        -- Event: Insert vs. Update
		If (@EventKey Is Null) Or (@EventKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert EventEvent
            Select @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Event] (EventKey, EventName, EventDescription, RecordStateKey) 
                Values (@EventKey, @EventName, @EventDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Event            
            Update [Entity].[Event]
            Set     EventName        = IsNull(@EventName, EventName),
                    EventDescription = IsNull(@EventDescription, EventDescription),
                    ModifiedDate        = GetUtcDate()
            Where EventKey = @EventKey
		End
        -- Location: Insert vs. Update
		If (@LocationKey Is Null) Or (@LocationKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert EventLocation
            Select @LocationKey = IsNull(NullIf(@LocationKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Location] (LocationKey, LocationName, LocationDescription, RecordStateKey) 
                Values (@LocationKey, @LocationName, @LocationDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Location            
            Update [Entity].[Location]
            Set     LocationName        = IsNull(@LocationName, LocationName),
                    LocationDescription = IsNull(@LocationDescription, LocationDescription),
                    ModifiedDate        = GetUtcDate()
            Where LocationKey = @LocationKey
		End
		-- EventLocation: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert EventLocation
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[EventLocation] (EventLocationKey, EventKey, LocationKey, LocationTypeKey, RecordStateKey) 
                Values (@Key, @EventKey, @LocationKey, NullIf(@LocationTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Location
            Update [Entity].[EventLocation]
            Set     LocationTypeKey     = NullIf(@LocationTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   EventLocationKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
