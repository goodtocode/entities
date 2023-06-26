Create PROCEDURE [EntityCode].[SlotTimeRangeSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @SlotKey			    Uniqueidentifier,
	@SlotName			    nvarchar(50),
	@SlotDescription	    nvarchar(2000),	
    @BeginDate              datetime,
    @EndDate                datetime,
    @TimeTypeKey			Uniqueidentifier
AS
	-- Local variables
    Declare @TimeRangeId As Int = -1
	Declare @TimeRangeKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'

	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), [SlotTimeRangeKey]) From [Entity].[SlotTimeRange] Where [SlotTimeRangeId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([SlotTimeRangeId], -1) From [Entity].[SlotTimeRange] Where [SlotTimeRangeKey] = @Key
		
    -- Save Time
	Select Top 1 @TimeRangeId = IsNull(TimeRangeId, @TimeRangeId), @TimeRangeKey = IsNull(NullIf(@TimeRangeKey, '00000000-0000-0000-0000-000000000000'), [TimeRangeKey]) From [Entity].[TimeRange] TR Where BeginDate = @BeginDate And EndDate = @EndDate
	-- Insert-only table
	If (@TimeRangeId Is Null) Or (@TimeRangeId = -1)
	Begin
        Select @TimeRangeKey = IsNull(NullIf(@TimeRangeKey, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[TimeRange]	(TimeRangeKey, BeginDate, EndDate)
			Values	(@TimeRangeKey, @BeginDate, @EndDate)	
        Select @TimeRangeId = SCOPE_IDENTITY()
	End
		
    -- Slot
	If (@SlotKey Is Null) Or (@SlotKey = '00000000-0000-0000-0000-000000000000')
	Begin
        -- Insert Slot
        Select @SlotKey = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[Slot] (SlotKey, SlotName, SlotDescription, RecordStateKey) 
            Values (@Key, @SlotName, @SlotDescription, '00000000-0000-0000-0000-000000000000')            
	End
	Else
	Begin
        -- Update Slot         
        Update [Entity].[Slot]
        Set     SlotName        = IsNull(@SlotName, SlotName),
                SlotDescription = IsNull(@SlotDescription, SlotDescription),
                ModifiedDate        = GetUtcDate()
        Where SlotKey = @SlotKey
	End
    -- SlotTimeRange
	If (@Id Is Null) Or (@Id = -1)
	Begin
        -- Insert SlotTimeRange
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[SlotTimeRange] (SlotTimeRangeKey, SlotKey, TimeRangeKey, TimeTypeKey, RecordStateKey) 
            Values (@Key, @SlotKey, @TimeRangeKey, NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
        Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
        -- Update [SlotTimeRange]
        Update [Entity].[SlotTimeRange]
        Set     TimeRangeKey        = IsNull(@TimeRangeKey, TimeRangeKey),
                TimeTypeKey         = NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                ModifiedDate        = GetUtcDate()
        Where   SlotTimeRangeKey = @Key
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
