Create PROCEDURE [EntityCode].[EventResourceSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@EventKey			    Uniqueidentifier,
	@EventName			    nvarchar(50),
	@EventDescription	    nvarchar(2000),	
    @ResourceKey			Uniqueidentifier,
	@ResourceName			nvarchar(50),
	@ResourceDescription	nvarchar(2000),	
    @ResourceTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@ResourceName			= RTRIM(LTRIM(@ResourceName))
	Select 	@ResourceDescription	= RTRIM(LTRIM(@ResourceDescription))
	-- Validate Data
	If  (@EventKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([EventResourceKey], @Key), @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), ResourceKey), 
            @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), EventKey) From [Entity].[EventResource] Where [EventResourceId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventResourceId], -1), @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), ResourceKey), @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), EventKey) From [Entity].[EventResource] Where [EventResourceKey] = @Key
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
        -- Resource: Insert vs. Update
		If (@ResourceKey Is Null) Or (@ResourceKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert EventResource
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
		-- EventResource: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert EventResource
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[EventResource] (EventResourceKey, EventKey, ResourceKey, ResourceTypeKey, RecordStateKey) 
                Values (@Key, @EventKey, @ResourceKey, NullIf(@ResourceTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Resource
            Update [Entity].[EventResource]
            Set     ResourceTypeKey     = NullIf(@ResourceTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   EventResourceKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
