Create Procedure [EntityCode].[ResourcePersonDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(ResourcePersonId, -1) From [Entity].[ResourcePerson] P Where [ResourcePersonKey] = @Key
            If (@Id <> -1)
			Begin
	            Update	[Entity].[ResourcePerson]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	ResourcePersonId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End