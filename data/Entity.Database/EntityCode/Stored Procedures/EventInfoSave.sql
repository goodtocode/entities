Create PROCEDURE [EntityCode].[EventInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@EventGroupKey			Uniqueidentifier,
	@EventTypeKey			Uniqueidentifier,
	@EventCreatorKey				Uniqueidentifier,
	@Name					nvarchar(50),
	@Description			nvarchar(200),
	@Slogan					nvarchar(50)
AS
	-- Local variables
	-- Initialize
	Select 	@Name			= RTRIM(LTRIM(@Name))
	Select 	@Description	= RTRIM(LTRIM(@Description))
	Select 	@Slogan			= RTRIM(LTRIM(@Slogan))

	-- Id and Key are both valid. Sync now.
	If (@Id <> -1) Select Top 1 @Key = IsNull([EventKey], @Key) From [Entity].[Event] Where [EventId] = @Id
	If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventId], -1) From [Entity].[Event] Where [EventKey] = @Key
	-- Insert vs. Update
	If (@Id Is Null) Or (@Id = -1)
	Begin
		-- Insert
		Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Entity].[Event] (EventKey, EventGroupKey, EventTypeKey, EventCreatorKey, EventName, EventDescription, EventSlogan, RecordStateKey)
			Values (@Key, @EventGroupKey, @EventTypeKey, @EventCreatorKey, @Name, @Description, @Slogan, '00000000-0000-0000-0000-000000000000')
		Select @Id = SCOPE_IDENTITY()
	End
	Else
	Begin
		-- Event master
		Update [Entity].[Event]
		Set	EventName			= @Name,
			EventDescription	= @Description,
			EventSlogan			= @Slogan,
			EventTypeKey		= @EventTypeKey,
				
			ModifiedDate		= GetUTCDate()
		Where	EventId	= @Id
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
