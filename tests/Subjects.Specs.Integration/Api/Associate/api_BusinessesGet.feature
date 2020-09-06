Feature: Api Businesses Get
	Get all Businesses from persistence

@query @webapi
Scenario: Get all businesses via Web API
	Given I request the list of businesses from the Web API
	When Businesses are queried via Web API
	Then All persisted businesses are returned from the Web API