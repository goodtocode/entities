Create PROCEDURE [EntityCode].[VentureResourceSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@VentureKey			    Uniqueidentifier,
	@VentureName			    nvarchar(50),
	@VentureDescription	    nvarchar(2000),	
    @ResourceKey			Uniqueidentifier,
	@ResourceName			nvarchar(50),
	@ResourceDescription	nvarchar(2000),	
    @ResourceTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@ResourceName			= RTRIM(LTRIM(@ResourceName))
	Select 	@ResourceDescription	= RTRIM(LTRIM(@ResourceDescription))
	-- Validate Data
	If  (@VentureKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([VentureResourceKey], @Key), @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), ResourceKey), 
            @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureResource] Where [VentureResourceId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureResourceId], -1), @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), ResourceKey), @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureResource] Where [VentureResourceKey] = @Key
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
        -- Resource: Insert vs. Update
		If (@ResourceKey Is Null) Or (@ResourceKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert VentureResource
            Select @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Resource] (ResourceKey, ResourceName, ResourceDescription, RecordStateKey) 
                Values (@ResourceKey, @ResourceName, @ResourceDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Resource            
            Update [Entity].[Resource]
            Set     ResourceName        = IsNull(@ResourceName, ResourceName),
                    ResourceDescription = IsNull(@ResourceDescription, ResourceDescription),
                    ModifiedDate        = GetUtcDate()
            Where ResourceKey = @ResourceKey
		End
		-- VentureResource: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert VentureResource
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[VentureResource] (VentureResourceKey, VentureKey, ResourceKey, ResourceTypeKey, RecordStateKey) 
                Values (@Key, @VentureKey, @ResourceKey, NullIf(@ResourceTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Resource
            Update [Entity].[VentureResource]
            Set     ResourceTypeKey     = NullIf(@ResourceTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   VentureResourceKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
