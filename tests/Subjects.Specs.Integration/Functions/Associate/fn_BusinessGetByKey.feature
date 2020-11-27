Feature: Fn Business Get by Key
	Get a Business from persistence

@query @azureFunction
Scenario: Get a business by key via Azure Function
	Given I have a business key to get from the Azure Function
	When Business is queried by key via Azure Function
	Then the matching business is returned from the Azure Function
