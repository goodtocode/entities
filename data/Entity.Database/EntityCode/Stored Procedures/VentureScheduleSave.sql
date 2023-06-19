Create PROCEDURE [EntityCode].[VentureScheduleSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@VentureKey			    Uniqueidentifier,
	@VentureName			    nvarchar(50),
	@VentureDescription	    nvarchar(2000),	
    @ScheduleKey			Uniqueidentifier,
	@ScheduleName			nvarchar(50),
	@ScheduleDescription	nvarchar(2000),	
    @ScheduleTypeKey		Uniqueidentifier
AS
	-- Initialize
	Select 	@ScheduleName			= RTRIM(LTRIM(@ScheduleName))
	Select 	@ScheduleDescription	= RTRIM(LTRIM(@ScheduleDescription))
	-- Validate Data
	If  (@VentureKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([VentureScheduleKey], @Key), @ScheduleKey = IsNull(NullIf(@ScheduleKey, '00000000-0000-0000-0000-000000000000'), ScheduleKey), 
            @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureSchedule] Where [VentureScheduleId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureScheduleId], -1), @ScheduleKey = IsNull(NullIf(@ScheduleKey, '00000000-0000-0000-0000-000000000000'), ScheduleKey), @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), VentureKey) From [Entity].[VentureSchedule] Where [VentureScheduleKey] = @Key
        -- Venture: Insert vs. Update
		If (@VentureKey Is Null) Or (@VentureKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert VentureVenture
            Select @VentureKey = IsNull(NullIf(@VentureKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Venture] (VentureKey, VentureName, VentureDescription, RecordStateKey) 
                Values (@VentureKey, @VentureName, @VentureDescription, '00000000-0000-0000-0000-000000000000')
		End
		Else
		Begin
            -- Update Venture            
            Update [Entity].[Venture]
            Set     VentureName        = IsNull(@VentureName, VentureName),
                    VentureDescription = IsNull(@VentureDescription, VentureDescription),
                    ModifiedDate        = GetUtcDate()
            Where VentureKey = @VentureKey
		End
        -- Schedule: Insert vs. Update
		If (@ScheduleKey Is Null) Or (@ScheduleKey = '00000000-0000-0000-0000-000000000000')
		Begin
            -- Insert VentureSchedule
            Select @ScheduleKey = IsNull(NullIf(@ScheduleKey, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[Schedule] (ScheduleKey, ScheduleName, ScheduleDescription, RecordStateKey) 
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
		-- VentureSchedule: Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert VentureSchedule
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[VentureSchedule] (VentureScheduleKey, VentureKey, ScheduleKey, ScheduleTypeKey, RecordStateKey) 
                Values (@Key, @VentureKey, @ScheduleKey, NullIf(@ScheduleTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
            -- Update Schedule
            Update [Entity].[VentureSchedule]
            Set     ScheduleTypeKey     = NullIf(@ScheduleTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                    ModifiedDate        = GetUtcDate()
            Where   VentureScheduleKey = @Key
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
