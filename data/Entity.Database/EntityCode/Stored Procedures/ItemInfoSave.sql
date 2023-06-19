Create PROCEDURE [EntityCode].[ItemInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@Name					nvarchar(50),
	@Description			nvarchar(200),
    @ItemTypeKey			Uniqueidentifier
AS
	-- Local variables
	-- Initialize
	Select 	@Name			= RTRIM(LTRIM(@Name))
	Select 	@Description	= RTRIM(LTRIM(@Description))

	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([ItemKey], @Key) From [Entity].[Item] Where [ItemId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([ItemId], -1) From [Entity].[Item] Where [ItemKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[Item] (ItemKey, ItemName, ItemDescription, ItemTypeKey, RecordStateKey)
			Values (@Key, @Name, @Description, @ItemTypeKey, '00000000-0000-0000-0000-000000000000')
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- Item master
		Update [Entity].[Item]
		Set	ItemName			= @Name,
			ItemDescription	    = @Description,
            ItemTypeKey         = @ItemTypeKey,
				
			ModifiedDate		= GetUTCDate()
		Where	ItemId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
