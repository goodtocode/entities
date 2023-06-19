Create PROCEDURE [EntityCode].[VentureLocationSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@VentureKey			    Uniqueidentifier,
	@VentureName			    nvarchar(50),
	@VentureDescription	    nvarchar(2000),	
    @LocationKey			Uniqueidentifier,
	@LocationName			nvarchar(50),
	@LocationDescription	nvarchar(2000),	
    @LocationTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@LocationName			= RTRIM(LTRIM(@LocationName))
	Select 	@LocationDescription	= RTRIM(LTRIM(@LocationDescription))
	-- Validate Data
	If  (@VentureKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([VentureLocationKey], @Key), @LocationKey = IsNull(NullIf(@LocationKey, '00000000-0000-0000-0000-000000000000'), LocationKey), 
            @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureLocation] Where [VentureLocationId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureLocationId], -1), @LocationKey = IsNull(NullIf(@LocationKey, '00000000-0000-0000-0000-000000000000'), LocationKey), @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureLocation] Where [VentureLocationKey] = @Key
        -- Venture: Insert vs. Update
		If (@VentureKey Is Null) Or (@VentureKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert VentureVenture
            Select @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Venture] (VentureKey, VentureName, VentureDescription, RecordStateKey) 
                Values (@VentureKey, @VentureName, @VentureDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Venture            
            Update [Entity].[Venture]
            Set     VentureName        = IsNull(@VentureName, VentureName),
                    VentureDescription = IsNull(@VentureDescription, VentureDescription),
                    ModifiedDate        = GetUtcDate()
            Where VentureKey = @VentureKey
		End
        -- Location: Insert vs. Update
		If (@LocationKey Is Null) Or (@LocationKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert VentureLocation
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
		-- VentureLocation: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert VentureLocation
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[VentureLocation] (VentureLocationKey, VentureKey, LocationKey, LocationTypeKey, RecordStateKey) 
                Values (@Key, @VentureKey, @LocationKey, NullIf(@LocationTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Location
            Update [Entity].[VentureLocation]
            Set     LocationTypeKey     = NullIf(@LocationTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   VentureLocationKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
