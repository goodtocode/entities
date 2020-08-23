Feature: Schedule Query
	Get a Schedule from query

@query
Scenario: Get a Schedule by key via Query
	Given I have a Schedule key that can be Queried
	When Schedule is read by key via Query
		And the Schedule exists in Query
	Then the matching Schedule is returned from the Query