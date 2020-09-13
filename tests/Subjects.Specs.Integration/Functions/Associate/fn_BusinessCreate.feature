Feature: Fn Business Create
	Create a new business in persistence

@command @azureFunction
Scenario: Create a new business via Azure Function
	Given I have a new business for the Azure Function
	When Business is created via Azure Function
	Then the business is inserted to persistence from the Azure Function
