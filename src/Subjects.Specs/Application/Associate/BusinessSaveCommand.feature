Feature: Business Save Command
	Create and update a business in persistence

@command @entityFramework
Scenario: Create a new business via Entity Framework
	Given A new Business has been created
		And a business key has been provided
		And a business name has been provided
	When the Business does not exist in persistence by key
		And Business is inserted via Entity Framework
	Then the new business can be queried by key