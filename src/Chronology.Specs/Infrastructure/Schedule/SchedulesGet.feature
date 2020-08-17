Feature: Schedulees Get
	Get all Schedulees from persistence

@query @entityFramework
Scenario: Get all Schedulees via Entity framework
	Given I request the list of Schedulees
	When Schedulees are queried via Entity framework
	Then All persisted Schedulees are returned