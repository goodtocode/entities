Create PROCEDURE [EntityCode].[EntityAppointmentSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@EntityKey			    Uniqueidentifier,
    @AppointmentKey			Uniqueidentifier,
	@AppointmentName		nvarchar(50),
	@AppointmentDescription	nvarchar(2000),
    @BeginDate				datetime,
	@EndDate				datetime
AS
    -- Local variables
    Declare @TimeRangeId As Int = -1
	Declare @TimeRangeKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
    -- Initialize
	Select 	@AppointmentName			= RTRIM(LTRIM(@AppointmentName))
	Select 	@AppointmentDescription	= RTRIM(LTRIM(@AppointmentDescription))
	-- Validate Data
	If  (@EntityKey <> '00000000-0000-0000-0000-000000000000')
	Begin
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

		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([EntityAppointmentKey], @Key), @AppointmentKey = IsNull(NullIf(@AppointmentKey, '00000000-0000-0000-0000-000000000000'), AppointmentKey), 
            @EntityKey = IsNull(NullIf(@EntityKey, '00000000-0000-0000-0000-000000000000'), EntityKey) From [Entity].[EntityAppointment] Where [EntityAppointmentId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EntityAppointmentId], -1), @AppointmentKey = IsNull(NullIf(@AppointmentKey, '00000000-0000-0000-0000-000000000000'), AppointmentKey), @EntityKey = IsNull(NullIf(@EntityKey, '00000000-0000-0000-0000-000000000000'), EntityKey) From [Entity].[EntityAppointment] Where [EntityAppointmentKey] = @Key
        -- Appointment: Insert vs. Update
		If (@AppointmentKey Is Null) Or (@AppointmentKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert EntityAppointment
            Select @AppointmentKey = IsNull(NullIf(@AppointmentKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Appointment] (AppointmentKey, AppointmentName, AppointmentDescription, TimeRangeKey, SlotLocationKey, SlotResourceKey, RecordStateKey) 
                Values (@AppointmentKey, @AppointmentName, @AppointmentDescription, @TimeRangeKey, NULL, NULL, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Appointment            
            Update [Entity].[Appointment]
            Set     AppointmentName         = IsNull(@AppointmentName, AppointmentName),
                    AppointmentDescription  = IsNull(@AppointmentDescription, AppointmentDescription),
                    TimeRangeKey            = IsNull(@TimeRangeKey, TimeRangeKey),
                    ModifiedDate            = GetUtcDate()
            Where AppointmentKey = @AppointmentKey
		End
		-- EntityAppointment: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert EntityAppointment
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[EntityAppointment] (EntityAppointmentKey, EntityKey, AppointmentKey, RecordStateKey)
                Values (@Key, @EntityKey, @AppointmentKey, '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Appointment
            Update [Entity].[EntityAppointment]
            Set     ModifiedDate        = GetUtcDate()
            Where   EntityAppointmentKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]