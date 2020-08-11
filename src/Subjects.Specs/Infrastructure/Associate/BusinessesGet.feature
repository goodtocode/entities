Feature: Businesses Get
	Get all Businesses from persistence

@query @entityFramework
Scenario: Get all businesses via Entity framework
	Given I request the list of businesses
	When Businesses are queried via Entity framework
	Then All persisted businesses are returned