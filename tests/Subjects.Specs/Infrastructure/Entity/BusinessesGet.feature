Feature: Businesses Get
	Get all Businesses from persistence

@query @azureFunction
Scenario: Get all businesses via Azure Function
	Given I request the list of businesses
	When Businesses are queried via Azure Function
	Then All persisted businesses are returned