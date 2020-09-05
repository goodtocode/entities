Feature: Api Business Get by Key
	Get a Business from persistence

@query @azureFunction
Scenario: Get a business by key via Azure Function
	Given I have a business key
	When Business is queried by key via Azure Function
	Then the matching business is returned
