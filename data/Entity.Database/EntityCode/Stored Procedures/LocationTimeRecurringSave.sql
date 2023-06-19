Create PROCEDURE [EntityCode].[LocationTimeRecurringSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @BeginDay               int,
    @EndDay                 int,
    @BeginTime              datetime,
    @EndTime                datetime,
    @TimeTypeKey			Uniqueidentifier,
    @LocationKey			Uniqueidentifier
AS
	-- Local variables
    Declare @TimeRecurringId As Int = -1
	Declare @TimeRecurringKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
    
	-- Validate Data
	If  (@LocationKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([LocationTimeRecurringKey], @Key) From [Entity].[LocationTimeRecurring] Where [LocationTimeRecurringId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([LocationTimeRecurringId], -1) From [Entity].[LocationTimeRecurring] Where [LocationTimeRecurringKey] = @Key

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
        -- LocationTimeRecurring
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert LocationTimeRecurring
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[LocationTimeRecurring] (LocationTimeRecurringKey, LocationKey, TimeRecurringKey, TimeTypeKey, RecordStateKey) 
                Values (@Key, @LocationKey, @TimeRecurringKey, NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
            Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update [LocationTimeRecurring]
            Update [Entity].[LocationTimeRecurring]
            Set     LocationKey        = IsNull(@LocationKey, LocationKey),
                    TimeRecurringKey        = IsNull(@TimeRecurringKey, TimeRecurringKey),
                    TimeTypeKey        = NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   LocationTimeRecurringKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
