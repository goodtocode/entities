Create PROCEDURE [EntityCode].[VentureAppointmentSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@VentureKey			    Uniqueidentifier,
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
	If  (@VentureKey <> '00000000-0000-0000-0000-000000000000')
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
		If (@Id <> -1) Select Top 1 @Key = IsNull([VentureAppointmentKey], @Key), @AppointmentKey = IsNull(NullIf(@AppointmentKey, '00000000-0000-0000-0000-000000000000'), AppointmentKey), 
            @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureAppointment] Where [VentureAppointmentId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureAppointmentId], -1), @AppointmentKey = IsNull(NullIf(@AppointmentKey, '00000000-0000-0000-0000-000000000000'), AppointmentKey), @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureAppointment] Where [VentureAppointmentKey] = @Key
        -- Appointment: Insert vs. Update
		If (@AppointmentKey Is Null) Or (@AppointmentKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert VentureAppointment
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
		-- VentureAppointment: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert VentureAppointment
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[VentureAppointment] (VentureAppointmentKey, VentureKey, AppointmentKey, RecordStateKey) 
                Values (@Key, @VentureKey, @AppointmentKey, '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Appointment
            Update [Entity].[VentureAppointment]
            Set     ModifiedDate        = GetUtcDate()
            Where   VentureAppointmentKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]