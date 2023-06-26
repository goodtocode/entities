Create VIEW [EntityCode].[EntityDetail]
	AS 
SELECT  ED.[EntityDetailId] As Id,
        ED.[EntityDetailKey] As [Key],
        ED.[EntityKey],
        ED.[DetailKey],
        D.[DetailTypeKey] As DetailTypeKey,
        D.[DetailData],
        DT.[DetailTypeName] As [Name],
        DT.[DetailTypeDescription] As [Description],
		ED.CreatedDate,
		ED.ModifiedDate
  FROM [Entity].[EntityDetail] ED
  Join [Entity].[Detail] D On ED.DetailKey = D.DetailKey
  Join [Entity].[DetailType] DT On D.DetailTypeKey = DT.DetailTypeKey
