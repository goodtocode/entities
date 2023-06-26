Create PROCEDURE [EntityCode].[ResourceInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@Name			        nvarchar(50),
	@Description	        nvarchar(2000)
AS
   
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([ResourceKey], @Key) From [Entity].[Resource] Where [ResourceId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([ResourceId], -1) From [Entity].[Resource] Where [ResourceKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
        -- Insert Resource
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[Resource] (ResourceKey, RecordStateKey) 
            Values (@Key, '00000000-0000-0000-0000-000000000000')
        Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
        -- Update     
        Update [Entity].[Resource]
        Set     ResourceName        = IsNull(@Name, ResourceName),
                ResourceDescription = IsNull(@Description, ResourceDescription),
                
                ModifiedDate        = GetUtcDate()
        Where ResourceId = @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
