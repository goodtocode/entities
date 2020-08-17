Feature: Schedule Update
	Update a new Schedule into persistence

@command @entityFramework
Scenario: Update a new Schedule via Entity Framework
	Given An existing Schedule has been queried
		And a Schedule was found in persistence
	When the Schedule name changes
		And Schedule is Updated via Entity Framework
	Then the existing Schedule can be queried by key
		And the Schedule name matches the new name