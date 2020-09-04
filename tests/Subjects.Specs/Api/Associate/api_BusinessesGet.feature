Feature: Businesses Get from Web API
	Get all Businesses from Web API

@query @WebAPI
Scenario: Get all businesses via Web API
	Given I request the list of businesses from Web API
	When Businesses are Get via Web API
	Then All persisted businesses are returned from Web API