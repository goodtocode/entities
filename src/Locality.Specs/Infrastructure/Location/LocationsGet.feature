Feature: Location Get
	Get all Location from persistence

@query @entityFramework
Scenario: Get all Location via Entity framework
	Given I request the list of Location
	When Location are queried via Entity framework
	Then All persisted Location are returned