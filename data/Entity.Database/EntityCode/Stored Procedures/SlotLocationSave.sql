Create PROCEDURE [EntityCode].[SlotLocationSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@SlotKey			    Uniqueidentifier,
	@SlotName			    nvarchar(50),
	@SlotDescription	    nvarchar(2000),	
    @LocationKey			Uniqueidentifier,
	@LocationName			nvarchar(50),
	@LocationDescription	nvarchar(2000),	
    @LocationTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@LocationName			= RTRIM(LTRIM(@LocationName))
	Select 	@LocationDescription	= RTRIM(LTRIM(@LocationDescription))
	-- Validate Data
	If  (@SlotKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([SlotLocationKey], @Key), @LocationKey = IsNull(NullIf(@LocationKey, '00000000-0000-0000-0000-000000000000'), LocationKey), 
            @SlotKey = IsNull(NullIf(@SlotKey, '00000000-0000-0000-0000-000000000000'), SlotKey) From [Entity].[SlotLocation] Where [SlotLocationId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([SlotLocationId], -1), @LocationKey = IsNull(NullIf(@LocationKey, '00000000-0000-0000-0000-000000000000'), LocationKey), @SlotKey = IsNull(NullIf(@SlotKey, '00000000-0000-0000-0000-000000000000'), SlotKey) From [Entity].[SlotLocation] Where [SlotLocationKey] = @Key
        -- Slot: Insert vs. Update
		If (@SlotKey Is Null) Or (@SlotKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert SlotSlot
            Select @SlotKey = IsNull(NullIf(@SlotKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Slot] (SlotKey, SlotName, SlotDescription, RecordStateKey) 
                Values (@SlotKey, @SlotName, @SlotDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Slot            
            Update [Entity].[Slot]
            Set     SlotName        = IsNull(@SlotName, SlotName),
                    SlotDescription = IsNull(@SlotDescription, SlotDescription),
                    ModifiedDate        = GetUtcDate()
            Where SlotKey = @SlotKey
		End
        -- Location: Insert vs. Update
		If (@LocationKey Is Null) Or (@LocationKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert SlotLocation
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
		-- SlotLocation: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert SlotLocation
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[SlotLocation] (SlotLocationKey, SlotKey, LocationKey, LocationTypeKey, RecordStateKey) 
                Values (@Key, @SlotKey, @LocationKey, NullIf(@LocationTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Location
            Update [Entity].[SlotLocation]
            Set     LocationTypeKey     = NullIf(@LocationTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   SlotLocationKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
