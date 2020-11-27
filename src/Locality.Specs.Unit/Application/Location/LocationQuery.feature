Feature: Location Query
	Get a Location from query

@query
Scenario: Get a Location by key via Query
	Given I have a Location key that can be Queried
	When Location is read by key via Query
		And the Location exists in Query
	Then the matching Location is returned from the Query