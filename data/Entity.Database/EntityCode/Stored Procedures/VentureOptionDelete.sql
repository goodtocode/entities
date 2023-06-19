Create Procedure [EntityCode].[VentureOptionDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(VentureOptionId, -1) From [Entity].[VentureOption] P Where [VentureOptionKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[VentureOption]
	            Where	VentureOptionId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End