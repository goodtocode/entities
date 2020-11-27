Feature: Location Delete
	Delete a Location from persistence

@crud @entityFramework
Scenario: Delete an existing Location via Entity Framework
	Given An Location has been queried to be deleted
		And a Location to be deleted was found in persistence
	When the Location is Deleted via Entity Framework
	Then the deleted Location is queried by key
		And the Location is not found