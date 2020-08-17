Feature: Schedule Save Command
	Create and update a Schedule in persistence

@command @CQRS
Scenario: Create a new Schedule via CQRS Command
	Given A new Schedule Save Command has been created
		And the Schedule Save Command validates
	When the Schedule is inserted via CQRS Command
	Then the CQRS inserted Schedule can be queried by key