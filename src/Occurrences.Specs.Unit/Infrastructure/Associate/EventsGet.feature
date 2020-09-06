Feature: Events Get
	Get all Events from persistence

@query @entityFramework
Scenario: Get all Events via Entity framework
	Given I request the list of Events
	When Events are queried via Entity framework
	Then All persisted Events are returned