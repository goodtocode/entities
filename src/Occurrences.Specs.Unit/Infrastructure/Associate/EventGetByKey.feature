Feature: Event Get by Key
	Get a Event from persistence

@query @entityFramework
Scenario: Get a Event by key via Entity framework
	Given I have a Event key
	And the key is type Guid
	When Event is queried by key via Entity framework
		And the Event exists in persistence
	Then the matching Event is returned