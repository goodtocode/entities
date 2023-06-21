--
-- Property
--
Use EntityData
Select	*
From	[Entity].Property
Where PropertyKey = 'f57e9798-6e70-4887-9580-44cca5eed894'

--
-- EntityProperty
--
Use EntityData
Select	*
From	[Entity].[PropertyEntity] PC
Join [Entity].[Person] P On PC.EntityID = P.EntityID
Join [Entity].[Property] Pr on PC.PropertyID = Pr.PropertyID
Where Pr.PropertyKey = 'f57e9798-6e70-4887-9580-44cca5eed894'



--
-- From PersonInfoSave
--
-- Parameters
Declare @Gender As nvarchar(10) = ''
-- Locals
Declare @GenderPropertyID As int
Declare @MalePropertyID As Int
-- Look for @Gender match on code. If not, default to male PropertyID
Select @MalePropertyID = PropertyID From [EntityData].[Entity].[Property] Where PropertyKey = 'f57e9798-6e70-4887-9580-44cca5eed894'
Select @GenderPropertyID = IsNull(NullIf(P.PropertyID, ''), @MalePropertyID)
	From [EntityData].[Entity].[Property] P
	Join [EntityData].[Entity].[PropertyGroup] PG On P.PropertyGroupID = PG.PropertyGroupID
	Where PG.PropertyGroupKey = N'b997d822-c6d1-4c0f-877b-5d8e8aa6cc99' And P.PropertyCode = @Gender
If @GenderPropertyID Is Null
Begin
	Select 'isnull'
End

Select @MalePropertyID As MaleID, IsNull(@GenderPropertyID, @MalePropertyID) PropID