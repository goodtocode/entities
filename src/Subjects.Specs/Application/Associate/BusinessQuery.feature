Feature: Business Query
	Get a Business from query

@query
Scenario: Get a business by key via Query
	Given I have a business key that can be Queried
	When Business is read by key via Query
		And the business exists in Query
	Then the matching business is returned from the Query