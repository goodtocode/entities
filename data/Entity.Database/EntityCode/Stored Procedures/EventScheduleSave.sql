Create PROCEDURE [EntityCode].[EventScheduleSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@EventKey			    Uniqueidentifier,
	@EventName			    nvarchar(50),
	@EventDescription	    nvarchar(2000),	
    @ScheduleKey			Uniqueidentifier,
	@ScheduleName			nvarchar(50),
	@ScheduleDescription	nvarchar(2000),	
    @ScheduleTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@ScheduleName			= RTRIM(LTRIM(@ScheduleName))
	Select 	@ScheduleDescription	= RTRIM(LTRIM(@ScheduleDescription))
	-- Validate Data
	If  (@EventKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([EventScheduleKey], @Key), @ScheduleKey = IsNull(NullIf(@ScheduleKey, '00000000-0000-0000-0000-000000000000'), ScheduleKey), 
            @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), EventKey) From [Entity].[EventSchedule] Where [EventScheduleId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventScheduleId], -1), @ScheduleKey = IsNull(NullIf(@ScheduleKey, '00000000-0000-0000-0000-000000000000'), ScheduleKey), @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), EventKey) From [Entity].[EventSchedule] Where [EventScheduleKey] = @Key
        -- Event: Insert vs. Update
		If (@EventKey Is Null) Or (@EventKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert EventEvent
            Select @EventKey = IsNull(NullIf(@EventKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Event] (EventKey, EventName, EventDescription, RecordStateKey) 
                Values (@EventKey, @EventName, @EventDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Event            
            Update [Entity].[Event]
            Set     EventName        = IsNull(@EventName, EventName),
                    EventDescription = IsNull(@EventDescription, EventDescription),
                    ModifiedDate        = GetUtcDate()
            Where EventKey = @EventKey
		End
        -- Schedule: Insert vs. Update
		If (@ScheduleKey Is Null) Or (@ScheduleKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert EventSchedule
            Select @ScheduleKey = IsNull(NullIf(@ScheduleKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Schedule] (ScheduleKey, ScheduleName, ScheduleDescription,RecordStateKey) 
                Values (@ScheduleKey, @ScheduleName, @ScheduleDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Schedule            
            Update [Entity].[Schedule]
            Set     ScheduleName        = IsNull(@ScheduleName, ScheduleName),
                    ScheduleDescription = IsNull(@ScheduleDescription, ScheduleDescription),
                    ModifiedDate        = GetUtcDate()
            Where ScheduleKey = @ScheduleKey
		End
		-- EventSchedule: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert EventSchedule
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[EventSchedule] (EventScheduleKey, EventKey, ScheduleKey, ScheduleTypeKey, RecordStateKey) 
                Values (@Key, @EventKey, @ScheduleKey, NullIf(@ScheduleTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Schedule
            Update [Entity].[EventSchedule]
            Set     ScheduleTypeKey     = NullIf(@ScheduleTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   EventScheduleKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
