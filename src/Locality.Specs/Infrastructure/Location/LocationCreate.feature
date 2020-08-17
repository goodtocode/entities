Feature: Location Create
	Create a new Location in persistence

@command @entityFramework
Scenario: Create a new Location via Entity Framework
	Given A new Location has been created
	When the Location does not exist in persistence by key
		And Location is inserted via Entity Framework
	Then the new Location can be queried by key