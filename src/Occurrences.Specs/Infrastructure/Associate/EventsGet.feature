Feature: Eventes Get
	Get all Eventes from persistence

@query @entityFramework
Scenario: Get all Eventes via Entity framework
	Given I request the list of Eventes
	When Eventes are queried via Entity framework
	Then All persisted Eventes are returned