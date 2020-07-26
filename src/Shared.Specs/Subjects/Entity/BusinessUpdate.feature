Feature: Business Update
	Update a new business into persistence

@command @azureFunction
Scenario: Update a new business via Azure Function
	Given I have an empty business key
		And the business name is provided
	When Business is posted via Azure Function
		And the business does not exist in persistence
	Then the business is updated in persistence

@command @entityFramework
Scenario: Update a new business via Entity Framework
	Given I have an empty business key
		And the business name is provided
	When Business is posted via Entity Framework
		And the business does not exist in persistence
	Then the business is updated in persistence