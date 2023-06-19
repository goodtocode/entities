Create PROCEDURE [EntityCode].[SlotInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@Name			        nvarchar(50),
	@Description	        nvarchar(2000)
AS
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([SlotKey], @Key) From [Entity].[Slot] Where [SlotId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([SlotId], -1) From [Entity].[Slot] Where [SlotKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
        -- Insert Slot
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[Slot] (SlotKey, SlotName, SlotDescription, RecordStateKey) 
            Values (@Key, @Name, @Description, '00000000-0000-0000-0000-000000000000')
        Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
        -- Update Slot         
        Update [Entity].[Slot]
        Set     SlotName        = IsNull(@Name, SlotName),
                SlotDescription = IsNull(@Description, SlotDescription),
                ModifiedDate        = GetUtcDate()
        Where SlotKey = @Key
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
