Feature: Event Create
	Create a new Event in persistence

@crud @entityFramework
Scenario: Create a new Event via Entity Framework
	Given A new Event has been created
	When the Event does not exist in persistence by key
		And Event is inserted via Entity Framework
	Then the new Event can be queried by key