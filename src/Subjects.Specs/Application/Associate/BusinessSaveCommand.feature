Feature: Business Save Command
	Create and update a business in persistence

@command @CQRS
Scenario: Create a new business via CQRS Command
	Given A new Business Save Command has been created
		And a business key has been provided
	When the Business is inserted via CQRS Command
	Then the CQRS inserted business can be queried by key