Create Procedure [EntityCode].[EventDetailDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(EventDetailId, -1) From [Entity].[EventDetail] P Where [EventDetailKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[EventDetail]
	            Where	EventDetailId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End