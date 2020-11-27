Feature: Schedule Get by Key
	Get a Schedule from persistence

@query @entityFramework
Scenario: Get a Schedule by key via Entity framework
	Given I have a Schedule key
	And the key is type Guid
	When Schedule is queried by key via Entity framework
		And the Schedule exists in persistence
	Then the matching Schedule is returned