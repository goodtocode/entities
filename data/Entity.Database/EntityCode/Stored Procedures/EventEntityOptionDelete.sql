Create Procedure [EntityCode].[EventEntityOptionDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(EventEntityOptionId, -1) From [Entity].[EventEntityOption] P Where [EventEntityOptionKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[EventEntityOption]
	            Where	EventEntityOptionId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End