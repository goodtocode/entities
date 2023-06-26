	CREATE View [EntityCode].[ApplicationInfo]
AS 
	Select	A.ApplicationId As [Id], 
			A.ApplicationKey As [Key], 
			A.ApplicationName As Name, 
			A.ApplicationSlogan As Slogan, 
			A.SharedApplicationKey, 
			A.SharedSecret,
			A.BusinessEntityKey As BusinessKey,
			A.PrivacyUrl,
			A.TermsUrl,
			A.TermsRevisedDate,
			A.CreatedDate,
			A.ModifiedDate
	From	[Entity].[Application] A
