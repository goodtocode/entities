Feature: Business Update
	Update a new business into persistence

@command @azureFunction
Scenario: Update a new business via Web API
	Given I have an non empty business key for Web API
	When Business is Put via Web API
		And the business does not exist in persistence
	Then the business is updated in persistence
