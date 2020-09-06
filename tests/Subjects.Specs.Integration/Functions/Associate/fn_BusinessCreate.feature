Feature: Fn Business Insert
	Insert a new business into persistence

@command @azureFunction
Scenario: Insert a new business via Azure Function
	Given I have a new business for the Azure Function
	When Business is created via Azure Function
	Then the business is inserted to persistence from the Azure Function
