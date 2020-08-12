Feature: Business Query
	Get a Business from persistence

@query @entityFramework
Scenario: Get a business by key via Entity framework
	Given I have a business key
	And the key is type Guid
	When Business is queried by key via Entity framework
		And the business exists in persistence
	Then the matching business is returned