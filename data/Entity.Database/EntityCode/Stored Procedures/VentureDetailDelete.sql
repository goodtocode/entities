Create Procedure [EntityCode].[VentureDetailDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(VentureDetailId, -1) From [Entity].[VentureDetail] P Where [VentureDetailKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[VentureDetail]
	            Where	VentureDetailId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End