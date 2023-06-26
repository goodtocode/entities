Create Procedure [EntityCode].[EntityOptionDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(EntityOptionId, -1) From [Entity].[EntityOption] P Where [EntityOptionKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[EntityOption]
	            Where	EntityOptionId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End