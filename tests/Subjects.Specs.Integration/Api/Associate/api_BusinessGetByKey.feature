Feature: Api Business Get by Key
	Get a Business from persistence

@query @webapi
Scenario: Get a business by key via Web API
	Given I have a business key to get from the Web API
	When Business is queried by key via Web API
	Then the matching business is returned from the Web API
