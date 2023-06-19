Create VIEW [EntityCode].[VentureDetail]
	AS 
SELECT  VD.[VentureDetailId] As Id,
        VD.[VentureDetailKey] As [Key],
        VD.[VentureKey],
        VD.[DetailKey],
        D.[DetailTypeKey] As DetailTypeKey,
        D.[DetailData],
        DT.[DetailTypeName] As [Name],
        DT.[DetailTypeDescription] As [Description],
		VD.CreatedDate,
		VD.ModifiedDate
  FROM [Entity].[VentureDetail] VD
  Join [Entity].[Detail] D On VD.DetailKey = D.DetailKey
  Join [Entity].[DetailType] DT On D.DetailTypeKey = DT.DetailTypeKey
