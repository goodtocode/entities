Create PROCEDURE [EntityCode].[VentureDetailSave]
    @Id                 Int,
    @Key				Uniqueidentifier,
	@VentureKey			Uniqueidentifier,
	@DetailTypeKey		Uniqueidentifier,
	@DetailData		    nvarchar(1000)
AS
	-- Initialize
    Declare	@DetailKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
	-- First find match to flip to update if necessary
	Select	@Id = IsNull(ED.VentureDetailId, @Id), @Key = IsNull(ED.VentureDetailKey, @Key), @DetailKey = IsNull(ED.DetailKey, @DetailKey)
        From [Entity].[VentureDetail] ED Join [Entity].[Detail] D On ED.DetailKey = D.DetailKey 
        Where ED.VentureKey = @VentureKey And D.DetailTypeKey = @DetailTypeKey

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
            -- VentureDetail
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
			Insert Into [Entity].[VentureDetail] (VentureDetailKey, VentureKey, DetailKey)
				Values (@Key, @VentureKey, @DetailKey)
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
