Feature: Event Update
	Update a new Event into persistence

@crud @entityFramework
Scenario: Update a new Event via Entity Framework
	Given An existing Event has been queried
		And a Event was found in persistence
	When the Event name changes
		And Event is Updated via Entity Framework
	Then the existing Event can be queried by key
		And the Event name matches the new name