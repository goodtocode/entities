Feature: Event Save Command
	Create and update a Event in persistence

@command @CQRS
Scenario: Create a new Event via CQRS Command
	Given A new Event Save Command has been created
		And the Event Save Command validates
	When the Event is inserted via CQRS Command
	Then the CQRS inserted Event can be queried by key