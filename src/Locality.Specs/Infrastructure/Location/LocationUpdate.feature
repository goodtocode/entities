Feature: Location Update
	Update a new Location into persistence

@command @entityFramework
Scenario: Update a new Location via Entity Framework
	Given An existing Location has been queried
		And a Location was found in persistence
	When the Location name changes
		And Location is Updated via Entity Framework
	Then the existing Location can be queried by key
		And the Location name matches the new name