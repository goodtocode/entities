Feature: Business Get by Key
	Get a Business from persistence

@query @azureFunction
Scenario: Get a business by key via Azure Function
	Given I have a business key
	And the key is type Guid
	When Business is queried by key via Azure Function
		And the business exists in persistence
	Then the matching business is returned

@query @entityFramework
Scenario: Get a business by key via Entity framework
	Given I have a business key
	And the key is type Guid
	When Business is queried by key via Entity framework
		And the business exists in persistence
	Then the matching business is returned