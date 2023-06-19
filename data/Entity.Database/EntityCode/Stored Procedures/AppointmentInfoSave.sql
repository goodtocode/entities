Create PROCEDURE [EntityCode].[AppointmentInfoSave]
	@Id				        int,
    @Key				    Uniqueidentifier,
    @Name					nvarchar(50),
	@Description			nvarchar(200),
	@SlotLocationKey		Uniqueidentifier,
    @SlotResourceKey		Uniqueidentifier,
	@BeginDate				datetime,
	@EndDate				datetime
AS
	-- Local variables
    Declare @TimeRangeId As Int = -1
	Declare @TimeRangeKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'

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
	If (@Id <> -1) Select Top 1 @Key = IsNull(AppointmentKey, @Key) From [Entity].[Appointment] P Where P.[AppointmentId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(AppointmentId, -1) From [Entity].[Appointment] P Where [AppointmentKey] = @Key
	-- Insert vs. Do Nothing
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert Appointment			
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[Appointment] (AppointmentKey, AppointmentName, AppointmentDescription, SlotLocationKey, SlotResourceKey, TimeRangeKey, RecordStateKey)
			Values (@Key, @Name, @Description, NullIf(@SlotLocationKey, '00000000-0000-0000-0000-000000000000'), NullIf(@SlotResourceKey, '00000000-0000-0000-0000-000000000000'), 
                    @TimeRangeKey, '00000000-0000-0000-0000-000000000000')
		Select	@Id = Scope_Identity()
	End
    Else
    Begin
        Update [Entity].[Appointment]
        Set     AppointmentName         = @Name, 
                AppointmentDescription  = @Description, 
                SlotLocationKey         = NullIf(@SlotLocationKey, '00000000-0000-0000-0000-000000000000'), 
                SlotResourceKey         = NullIf(@SlotResourceKey, '00000000-0000-0000-0000-000000000000'), 
                TimeRangeKey            = @TimeRangeKey,
                ModifiedDate            = GETUTCDATE()
        Where   AppointmentId = @Id
    End

	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
