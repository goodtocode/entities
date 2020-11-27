Feature: Schedule Delete
	Delete a Schedule from persistence

@crud @entityFramework
Scenario: Delete an existing Schedule via Entity Framework
	Given An Schedule has been queried to be deleted
		And a Schedule to be deleted was found in persistence
	When the Schedule is Deleted via Entity Framework
	Then the deleted Schedule is queried by key
		And the Schedule is not found