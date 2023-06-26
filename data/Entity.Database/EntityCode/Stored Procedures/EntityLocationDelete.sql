Create Procedure [EntityCode].[EntityLocationDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			-- Id and Key are both valid. Sync now.
		    If (@Id <> -1) Select Top 1 @Key = IsNull([EntityLocationKey], @Key) From [Entity].[EntityLocation] Where [EntityLocationId] = @Id
		    If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EntityLocationId], -1) From [Entity].[EntityLocation] Where [EntityLocationKey] = @Key
            -- Validate
            If (@Id <> -1)
			Begin
	            Update	[Entity].[EntityLocation]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	EntityLocationId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End