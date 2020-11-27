Feature: Event Delete
	Delete a Event from persistence

@crud @entityFramework
Scenario: Delete an existing Event via Entity Framework
	Given An Event has been queried to be deleted
		And a Event to be deleted was found in persistence
	When the Event is Deleted via Entity Framework
	Then the deleted Event is queried by key
		And the Event is not found