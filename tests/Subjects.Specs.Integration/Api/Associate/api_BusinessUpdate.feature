Feature: Api Business Update
	Update a new business into persistence

@command @webapi
Scenario: Update an existing business via Web API
	Given I have an non empty business key for the Web API
		And the business name is provided for the Web API
	When Business is posted via Web API
	Then the business is updated in persistence when queried from Web API