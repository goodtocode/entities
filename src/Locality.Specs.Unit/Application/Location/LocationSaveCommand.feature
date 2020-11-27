Feature: Location Save Command
	Create and update a Location in persistence

@command @CQRS
Scenario: Create a new Location via CQRS Command
	Given A new Location Save Command has been created
		And the Location Save Command validates
	When the Location is inserted via CQRS Command
	Then the CQRS inserted Location can be queried by key