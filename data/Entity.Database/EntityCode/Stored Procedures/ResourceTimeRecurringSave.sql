Create PROCEDURE [EntityCode].[ResourceTimeRecurringSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @BeginDay               int,
    @EndDay                 int,
    @BeginTime              datetime,
    @EndTime                datetime,
    @TimeTypeKey			Uniqueidentifier,
    @ResourceKey			Uniqueidentifier,
	@ResourceName			nvarchar(50),
	@ResourceDescription	nvarchar(2000)
AS
	-- Local variables
    Declare @TimeRecurringId As Int = -1
	Declare @TimeRecurringKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
    
	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([ResourceTimeRecurringKey], @Key) From [Entity].[ResourceTimeRecurring] Where [ResourceTimeRecurringId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([ResourceTimeRecurringId], -1) From [Entity].[ResourceTimeRecurring] Where [ResourceTimeRecurringKey] = @Key

    -- TimeRecurring
	Select Top 1 @TimeRecurringId = IsNull(TimeRecurringId, @TimeRecurringId), @TimeRecurringKey = IsNull(NullIf(@TimeRecurringKey, '00000000-0000-0000-0000-000000000000'), [TimeRecurringKey]) From [Entity].[TimeRecurring] TR Where BeginDay = @BeginDay AND EndDay = @EndDay AND BeginTime = @BeginTime AND EndTime = @EndTime
	If (@TimeRecurringId Is Null) Or (@TimeRecurringId = -1)
	Begin
        Select @TimeRecurringKey = IsNull(NullIf(@TimeRecurringKey, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[TimeRecurring] (TimeRecurringKey, BeginDay, EndDay, BeginTime, EndTime) 
            Values (@TimeRecurringKey, @BeginDay, @EndDay, @BeginTime, @EndTime)
        Select @TimeRecurringId = SCOPE_IDENTITY()
	End
    
    -- Resource
    If (@ResourceKey Is Null) Or (@ResourceKey = '00000000-0000-0000-0000-000000000000')
	Begin
        -- Insert Resource
        Select @ResourceKey = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[Resource] (ResourceKey, ResourceName, ResourceDescription, RecordStateKey) 
            Values (@Key, @ResourceName, @ResourceDescription, '00000000-0000-0000-0000-000000000000')            
	End
	Else
	Begin
        -- Update Resource         
        Update [Entity].[Resource]
        Set     ResourceName        = IsNull(@ResourceName, ResourceName),
                ResourceDescription = IsNull(@ResourceDescription, ResourceDescription),
                ModifiedDate        = GetUtcDate()
        Where ResourceKey = @ResourceKey
	End        
    -- ResourceTimeRecurring
	If (@Id Is Null) Or (@Id = -1)
	Begin
        -- Insert ResourceTimeRecurring
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Insert Into [Entity].[ResourceTimeRecurring] (ResourceTimeRecurringKey, ResourceKey, TimeRecurringKey, TimeTypeKey, RecordStateKey) 
            Values (@Key, @ResourceKey, @TimeRecurringKey, NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'), '00000000-0000-0000-0000-000000000000')
        Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
        -- Update [ResourceTimeRecurring]
        Update [Entity].[ResourceTimeRecurring]
        Set     ResourceKey        = IsNull(@ResourceKey, ResourceKey),
                TimeRecurringKey        = IsNull(@TimeRecurringKey, TimeRecurringKey),
                TimeTypeKey        = NullIf(@TimeTypeKey, '00000000-0000-0000-0000-000000000000'),
                    
                ModifiedDate        = GetUtcDate()
        Where   ResourceTimeRecurringKey = @Key
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
