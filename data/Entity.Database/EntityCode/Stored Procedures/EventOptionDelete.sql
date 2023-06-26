Create Procedure [EntityCode].[EventOptionDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(EventOptionId, -1) From [Entity].[EventOption] P Where [EventOptionKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[EventOption]
	            Where	EventOptionId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End