Feature: Location Get by Key
	Get a Location from persistence

@query @entityFramework
Scenario: Get a Location by key via Entity framework
	Given I have a Location key
	And the key is type Guid
	When Location is queried by key via Entity framework
		And the Location exists in persistence
	Then the matching Location is returned