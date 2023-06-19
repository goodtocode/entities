Create Procedure [EntityCode].[VentureEntityOptionDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(VentureEntityOptionId, -1) From [Entity].[VentureEntityOption] P Where [VentureEntityOptionKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[VentureEntityOption]
	            Where	VentureEntityOptionId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End