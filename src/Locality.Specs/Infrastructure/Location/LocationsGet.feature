Feature: Locationes Get
	Get all Locationes from persistence

@query @entityFramework
Scenario: Get all Locationes via Entity framework
	Given I request the list of Locationes
	When Locationes are queried via Entity framework
	Then All persisted Locationes are returned