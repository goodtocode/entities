Create Procedure [EntityCode].[ResourceItemSave]
    @Id             	    int,
    @Key				    uniqueidentifier,
	@ResourceName			nvarchar(50),
	@ResourceDescription	nvarchar(50),
	@ItemName			    nvarchar(50),
	@ItemDescription	    nvarchar(50)
AS
	-- Local variables
    Declare @ResourceKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
    Declare @ItemKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
	-- Initialize
	Select	@Key			        = IsNull(@Key, '00000000-0000-0000-0000-000000000000')
	Select 	@ResourceName		    = RTRIM(LTRIM(@ResourceName))
	Select 	@ResourceDescription	= RTRIM(LTRIM(@ResourceDescription))
    Select 	@ItemName		        = RTRIM(LTRIM(@ItemName))
	Select 	@ItemDescription	    = RTRIM(LTRIM(@ItemDescription))
	
	-- Validate data that will be inserted/updated, and ensure basic values exist
	If ((@ResourceName <> '') Or (@ItemName <> ''))
	Begin
		-- Id and Key are both valid. Sync now.
        If (@Id <> -1) Select Top 1 @Key = IsNull(ResourceItemKey, @Key), @ResourceKey = ResourceKey, @ItemKey = ItemKey From [Entity].[ResourceItem] P Where [ResourceItemId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(ResourceItemId, -1), @ResourceKey = ResourceKey, @ItemKey = ItemKey From [Entity].[ResourceItem] P Where [ResourceItemKey] = @Key
		-- Insert vs Update		
		Begin Try
			If (@Id Is Null) Or (@Id = -1)
			Begin
				-- Create main entity record
				Select @ItemKey = IsNull(NullIf(@ItemKey, '00000000-0000-0000-0000-000000000000'), NewId())
				-- Create Item record
				Insert Into [Entity].[Item] (ItemKey, ItemName, ItemDescription, RecordStateKey)
					Values (@ItemKey, @ItemName, @ItemDescription, '00000000-0000-0000-0000-000000000000')
                -- Create Resource record
                Select @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[Resource] (ResourceKey, ResourceName, ResourceDescription, RecordStateKey)
                    Values (@ResourceKey, @ResourceName, @ResourceDescription, '00000000-0000-0000-0000-000000000000')
                -- Create ResourceItem record
				Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[ResourceItem] (ResourceItemKey, ResourceKey, ItemKey, RecordStateKey) 
                    Values (@Key, @ResourceKey, @ItemKey, '00000000-0000-0000-0000-000000000000')
				Select	@Id = SCOPE_IDENTITY()
			End
            Else
			Begin
				-- Resource
				Update P
				Set P.ResourceName			= @ResourceName, 
					P.ResourceDescription	= @ResourceDescription, 
					P.ModifiedDate			= GetUTCDate()
				From	[Entity].[Resource] P
				Where	P.ResourceKey = @ResourceKey
				-- Item
				Update P
				Set P.ItemName				= @ItemName, 
					P.ItemDescription		= @ItemDescription, 
					P.ModifiedDate			= GetUTCDate()
				From	[Entity].[Item] P
				Where	P.ItemKey = @ItemKey
			End
		End Try
		Begin Catch
			Exec [Activity].[ExceptionLogInsertByException];
		End Catch
	End	

	-- Return data
	Select	IsNull(@Id, -1) As [Id], IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
