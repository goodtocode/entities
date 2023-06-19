Create PROCEDURE [EntityCode].[EventDetailSave]
    @Id                 Int,
    @Key				Uniqueidentifier,
	@EventKey			Uniqueidentifier,
	@DetailTypeKey		Uniqueidentifier,
	@DetailData		    nvarchar(1000)
AS
	-- Initialize
    Declare	@DetailKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
	-- First find match to flip to update if necessary
	Select	@Id = IsNull(ED.EventDetailId, @Id), @Key = IsNull(ED.EventDetailKey, @Key), @DetailKey = IsNull(ED.DetailKey, @DetailKey)
        From [Entity].[EventDetail] ED Join [Entity].[Detail] D On ED.DetailKey = D.DetailKey 
        Where ED.EventKey = @EventKey And D.DetailTypeKey = @DetailTypeKey

	-- Do nothing if bad data
	If (@DetailTypeKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Insert vs Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Detail
            Select @DetailKey = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
			Insert Into [Entity].[Detail] (DetailKey, DetailTypeKey, DetailData)
				Values (@DetailKey, @DetailTypeKey, @DetailData)
            -- EventDetail
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
			Insert Into [Entity].[EventDetail] (EventDetailKey, EventKey, DetailKey)
				Values (@Key, @EventKey, @DetailKey)
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
			Update [Entity].[Detail]
			Set	DetailData	            = @DetailData,
				
				ModifiedDate			= GetUTCDate()
			Where DetailKey = @DetailKey
		End
	End
		
	-- Return ID
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
