Feature: Api Business Insert
	Insert a new business into persistence

@command @webapi
Scenario: Insert a new business via Web API
	Given I have a new business for the Web API
	When Business is created via Web API
	Then the business is inserted to persistence from the Web API
