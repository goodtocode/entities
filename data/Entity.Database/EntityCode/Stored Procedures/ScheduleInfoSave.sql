Create PROCEDURE [EntityCode].[ScheduleInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@Name			        nvarchar(50),
	@Description	        nvarchar(2000)
AS
   
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([ScheduleKey], @Key) From [Entity].[Schedule] Where [ScheduleId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([ScheduleId], -1) From [Entity].[Schedule] Where [ScheduleKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
        -- Insert Schedule
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[Schedule] (ScheduleKey, RecordStateKey) 
            Values (@Key, '00000000-0000-0000-0000-000000000000')
        Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
        -- Update     
        Update [Entity].[Schedule]
        Set     ScheduleName        = IsNull(@Name, ScheduleName),
                ScheduleDescription = IsNull(@Description, ScheduleDescription),
                
                ModifiedDate        = GetUtcDate()
        Where ScheduleId = @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
