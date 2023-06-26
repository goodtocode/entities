Create VIEW [EntityCode].[EventDetail]
	AS 
SELECT  ED.[EventDetailId] As Id,
        ED.[EventDetailKey] As [Key],
        ED.[EventKey],
        ED.[DetailKey],
        D.[DetailTypeKey] As DetailTypeKey,
        D.[DetailData],
        DT.[DetailTypeName] As [Name],
        DT.[DetailTypeDescription] As [Description],
		ED.CreatedDate,
		ED.ModifiedDate
  FROM [Entity].[EventDetail] ED
  Join [Entity].[Detail] D On ED.DetailKey = D.DetailKey
  Join [Entity].[DetailType] DT On D.DetailTypeKey = DT.DetailTypeKey
