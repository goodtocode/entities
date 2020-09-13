Feature: Api Business Create
	Create a new business in persistence

@command @webapi
Scenario: Create a new business via Web API
	Given I have a new business for the Web API
	When Business is created via Web API
	Then the business is inserted to persistence from the Web API
