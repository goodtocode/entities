Feature: Event Query
	Get a Event from query

@query
Scenario: Get a Event by key via Query
	Given I have a Event key that can be Queried
	When Event is read by key via Query
		And the Event exists in Query
	Then the matching Event is returned from the Query