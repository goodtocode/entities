--('00000000-0000-0000-0000-000000000000')
--
--Address
--
Use EntityData
Select	*
From	[EntityData].Geography.AddressEntity CA
Left Join	[EntityData].Geography.Address  A On CA.AddressID = A.AddressID
Left join [EntityData].Geography.PostalCode P On A.PostalCodeID = P.PostalCodeID
Left join [EntityData].Geography.LatLong L On A.LatLongID = L.LatLongID
Left Join [EntityData].Geography.AddressType AT on CA.AddressTypeID = AT.AddressTypeID
Where	CA.EntityID = '24b9f599-eb60-479b-b640-4b9407d79f2f'
Select	*
From	[EntityData].[Entity].Event E
Left Join	[EntityData].Geography.EventLocation  A On E.EventID = A.EventID
Left join [EntityData].Geography.Address Ad On A.AddressID = Ad.AddressID
Left join [EntityData].Geography.PostalCode P On Ad.PostalCodeID = P.PostalCodeID
Left join [EntityData].Geography.LatLong L On Ad.LatLongID = L.LatLongID
Where	E.EventCreatorID = '24b9f599-eb60-479b-b640-4b9407d79f2f'
Select	*
From	[EntityData].Geography.Address A
Left join [EntityData].Geography.PostalCode P On A.PostalCodeID = P.PostalCodeID
Left join [EntityData].Geography.LatLong L On A.LatLongID = L.LatLongID
Where	AddressID = 'd1a4d6a6-aaa2-4e93-85b9-c74ac836c7de'
Select	*
From	[EntityData].Geography.LatLong
--Exec EntityLatLongInsert 'd75db17d-1bb1-4a0c-b079-7d1754b050a8', '6855469f-bcee-481d-9380-0882b1833057'
Select	*
From	[EntityData].Geography.AddressType

--
--Countries
--
Use EntityData
Select	*
From	[EntityData].Geography.Country
Where	CountryName Like 'unit%'

Select *
	From	VGOConnect.[Entity].PostalCode P
	Join VGOConnect.[Entity].Country C On P.CountryID = C.CountryID
	Join VGOConnect.[Entity].State S On P.StateID = S.StateID
Where	PostalCode In ('02568', '02568')

--
--States
--
Use EntityData
Select	*
From	[EntityData].Geography.State S
Left Join	[EntityData].Geography.Country C On S.CountryID = C.CountryID
Where	StateName Like '%calif%'

--
--PostalCodes
--
Select	P.PostalCode, c.CountryName--, Count(*) --.PostalCode, S.StateName, C.CountryName
From	[EntityData].Geography.PostalCode as P
Left Join	[EntityData].Geography.State as S
	On P.stateID = S.STateID
Left Join	[EntityData].Geography.Country C
	On P.countryID = C.countryID
--Where C.CountryName = 'France'
Order By C.CountryName

--
--Lat Long
--
Use EntityData
Select	Top 100 *
From [EntityData].Geography.LatLong L
Left Join [EntityData].Geography.Address A On L.LatLongID = A.LatLongID

--
--Raw
--
Use EntityData
Select	Top 100 *
From	[EntityData].Geography.PostalCode
Use EntityData
Select	Top 100 *
From	[EntityData].Geography.Address
Order By CreatedDate Desc
Use EntityData
Select	Top 100 *
From	[EntityData].Geography.AddressEntity
Use EntityData
Select	Top 100 *
From	 [EntityData].Geography.LatLongTable

--
--Phone
--
Use EntityData
Select	*
From	[EntityData].Geography.PhoneNumberEntity
Select	*
From	[EntityData].Geography.PhoneNumber
Select	*
From	[EntityData].Geography.PhoneNumberType

--
--Email
--
Use EntityData
Select	*
From	[EntityData].Geography.Email
Select	*
From	[EntityData].Geography.EmailEntity
Select	*
From	[EntityData].Geography.EmailType

--
--Language
--
Use EntityData
Select	*
From	[EntityData].Geography.Language

-- Importing Postal Codes

--
-- INSERT POSTAL CODES
--
-- Initiate
Use EntityData
Go
Begin Tran
Declare @ActivityWorkflowID Uniqueidentifier = N'26D4CB2B-3645-43C2-B31E-1326B9FB54EF'
DECLARE @Data TABLE(PostalCodeID Uniqueidentifier, PostalCode varchar(30) NOT NULL);
-- Get dup field
INSERT INTO @Data
Select PostalCodeID, PostalCode
	From	VGOConnect.[Entity].PostalCode P
Where	PostalCodeID Not In (Select Min(PostalCodeID)
							From	VGOConnect.[Entity].PostalCode 
							Group By PostalCode, City, CountryID, StateID)
-- Source dup cleanup
Delete From VGOConnect.[Entity].Address Where PostalCodeID In (Select PostalCodeID From @Data)
Delete From VGOConnect.[Entity].PostalCode Where PostalCodeID In (Select PostalCodeID From @Data)
-- destination
Delete From [EntityData].Geography.PostalCode
Insert Into [EntityData].Geography.PostalCode (PostalCodeID, PostalCode,StateID, City, CountryID, LatLongID, CreatedActivityID)
Select	PostalCodeID, PostalCode,StateID, City, CountryID, LatLongID, @ActivityWorkflowID As CreatedActivityID 
	From VGOConnect.[Entity].PostalCode
Go
Rollback