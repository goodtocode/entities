Create PROCEDURE [EntityCode].[EntityTimeRecurringSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @BeginDay               int,
    @EndDay                 int,
    @BeginTime              datetime,
    @EndTime                datetime,
    @TimeTypeKey			Uniqueidentifier,
    @EntityKey			    Uniqueidentifier
AS
	-- Local variables
    Declare @TimeRecurringId As Int = -1
	Declare @TimeRecurringKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
    
	-- Validate Data
	If  (@EntityKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([EntityTimeRecurringKey], @Key) From [Entity].[EntityTimeRecurring] Where [EntityTimeRecurringId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EntityTimeRecurringId], -1) From [Entity].[EntityTimeRecurring] Where [EntityTimeRecurringKey] = @Key

        -- TimeRecurring
	    Select Top 1 @TimeRecurringId = IsNull(TimeRecurringId, @TimeRecurringId), @TimeRecurringKey = IsNull(NullIf(@TimeRecurringKey, '00000000-0000-0000-0000-000000000000'), [TimeRecurringKey]) From [Entity].[TimeRecurring] TR Where BeginDay = @BeginDay AND EndDay = @EndDay AND BeginTime = @BeginTime AND EndTime = @EndTime
	    -- TimeRecurring Insert only
	    If (@TimeRecurringId Is Null) Or (@TimeRecurringId = -1)
	    Begin
            Select @TimeRecurringKey = IsNull(NullIf(@TimeRecurringKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[TimeRecurring] (TimeRecurringKey, BeginDay, EndDay, BeginTime, EndTime) 
                Values (@TimeRecurringKey, @BeginDay, @EndDay, @BeginTime, @EndTime)
            Select @TimeRecurringId = SCOPE_IDENTITY()
	    End
        -- EntityTimeRecurring
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert EntityTimeRecurring
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[EntityTimeRecurring] (EntityTimeRecurringKey, EntityKey, TimeRecurringKey, TimeTypeKey, RecordStateKey) 
                Values (@Key, @EntityKey, @TimeRecurringKey, NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
            Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update [EntityTimeRecurring]
            Update [Entity].[EntityTimeRecurring]
            Set     EntityKey        = IsNull(@EntityKey, EntityKey),
                    TimeRecurringKey        = IsNull(@TimeRecurringKey, TimeRecurringKey),
                    TimeTypeKey        = NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   EntityTimeRecurringKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
