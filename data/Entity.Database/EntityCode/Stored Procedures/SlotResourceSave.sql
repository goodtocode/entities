Create PROCEDURE [EntityCode].[SlotResourceSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@SlotKey			    Uniqueidentifier,
	@SlotName			    nvarchar(50),
	@SlotDescription	    nvarchar(2000),	
    @ResourceKey			Uniqueidentifier,
	@ResourceName			nvarchar(50),
	@ResourceDescription	nvarchar(2000),	
    @ResourceTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@ResourceName			= RTRIM(LTRIM(@ResourceName))
	Select 	@ResourceDescription	= RTRIM(LTRIM(@ResourceDescription))
	-- Validate Data
	If  (@SlotKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([SlotResourceKey], @Key), @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), ResourceKey), 
            @SlotKey = IsNull(NullIf(@SlotKey, '00000000-0000-0000-0000-000000000000'), SlotKey) From [Entity].[SlotResource] Where [SlotResourceId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([SlotResourceId], -1), @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), ResourceKey), @SlotKey = IsNull(NullIf(@SlotKey, '00000000-0000-0000-0000-000000000000'), SlotKey) From [Entity].[SlotResource] Where [SlotResourceKey] = @Key
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
        -- Resource: Insert vs. Update
		If (@ResourceKey Is Null) Or (@ResourceKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert SlotResource
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
		-- SlotResource: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert SlotResource
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[SlotResource] (SlotResourceKey, SlotKey, ResourceKey, ResourceTypeKey, RecordStateKey) 
                Values (@Key, @SlotKey, @ResourceKey, NullIf(@ResourceTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Resource
            Update [Entity].[SlotResource]
            Set     ResourceTypeKey     = NullIf(@ResourceTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   SlotResourceKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
