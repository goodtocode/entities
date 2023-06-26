Create Procedure [EntityCode].[EntityDetailDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(EntityDetailId, -1) From [Entity].[EntityDetail] P Where [EntityDetailKey] = @Key
            If (@Id <> -1)
			Begin
	            Delete
	            From	[Entity].[EntityDetail]
	            Where	EntityDetailId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End