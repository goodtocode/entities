Feature: Business Insert
	Insert a new business into persistence

@command @azureFunction
Scenario: Insert a new business via Azure Function
	Given I have an empty business key
		And the business name is provided
	When Business is posted via Azure Function
		And the business does not exist in persistence
	Then the business is inserted to persistence
