Feature: Fn Businesses Get
	Get all Businesses from persistence

@query @azureFunction
Scenario: Get all businesses via Azure Function
	Given I request the list of businesses from the Azure Function
	When Businesses are queried via Azure Function
	Then All persisted businesses are returned from the Azure Function