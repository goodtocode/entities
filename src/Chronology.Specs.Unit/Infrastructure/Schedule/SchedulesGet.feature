Feature: Schedules Get
	Get all Schedules from persistence

@query @entityFramework
Scenario: Get all Schedules via Entity framework
	Given I request the list of Schedules
	When Schedules are queried via Entity framework
	Then All persisted Schedules are returned