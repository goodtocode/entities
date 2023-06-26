Create PROCEDURE [EntityCode].[SlotTimeRecurringSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @BeginDay               int,
    @EndDay                 int,
    @BeginTime              datetime,
    @EndTime                datetime,
    @TimeTypeKey			Uniqueidentifier,
    @TimeCycleKey			Uniqueidentifier,
    @SlotKey			    Uniqueidentifier,
	@SlotName			    nvarchar(50),
	@SlotDescription	    nvarchar(2000)
AS
	-- Local variables
    Declare @TimeRecurringId As Int = -1
	Declare @TimeRecurringKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
    
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), [SlotTimeRecurringKey]) From [Entity].[SlotTimeRecurring] Where [SlotTimeRecurringId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([SlotTimeRecurringId], -1) From [Entity].[SlotTimeRecurring] Where [SlotTimeRecurringKey] = @Key
    -- TimeRecurring
	Select Top 1 @TimeRecurringId = IsNull(TimeRecurringId, @TimeRecurringId), @TimeRecurringKey = IsNull(NullIf(@TimeRecurringKey, '00000000-0000-0000-0000-000000000000'), [TimeRecurringKey]) From [Entity].[TimeRecurring] TR Where BeginDay = @BeginDay AND EndDay = @EndDay AND BeginTime = @BeginTime AND EndTime = @EndTime AND TimeCycleKey = @TimeCycleKey
	If (@TimeRecurringId Is Null) Or (@TimeRecurringId = -1)
	Begin
        Select @TimeRecurringKey = IsNull(NullIf(@TimeRecurringKey, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[TimeRecurring] (TimeRecurringKey, BeginDay, EndDay, BeginTime, EndTime, TimeCycleKey) 
            Values (@TimeRecurringKey, @BeginDay, @EndDay, @BeginTime, @EndTime, @TimeCycleKey)
        Select @TimeRecurringId = SCOPE_IDENTITY()
	End
    -- Slot
    If (@SlotKey Is Null) Or (@SlotKey = '00000000-0000-0000-0000-000000000000')
	Begin
        -- Insert Slot
        Select @SlotKey = IsNull(NullIf(@SlotKey, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[Slot] (SlotKey, SlotName, SlotDescription, RecordStateKey) 
            Values (@SlotKey, @SlotName, @SlotDescription, '00000000-0000-0000-0000-000000000000')            
	End
	Else
	Begin
        -- Update Slot
        Update [Entity].[Slot]
        Set     SlotName        = IsNull(@SlotName, SlotName),
                SlotDescription = IsNull(@SlotDescription, SlotDescription),
                ModifiedDate    = GetUtcDate()
        Where SlotKey = @SlotKey
	End
    -- SlotTimeRecurring
	If (@Id Is Null) Or (@Id = -1)
	Begin
        -- Insert SlotTimeRecurring
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[SlotTimeRecurring] (SlotTimeRecurringKey, SlotKey, TimeRecurringKey, TimeTypeKey, RecordStateKey) 
            Values (@Key, @SlotKey, @TimeRecurringKey, NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
        Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
        -- Update [SlotTimeRecurring]
        Update [Entity].[SlotTimeRecurring]
        Set     SlotKey             = IsNull(@SlotKey, SlotKey),
                TimeRecurringKey    = IsNull(@TimeRecurringKey, TimeRecurringKey),
                TimeTypeKey         = NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                ModifiedDate        = GetUtcDate()
        Where   SlotTimeRecurringKey = @Key
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
