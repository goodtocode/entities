Feature: Business Create
	Create a new business in persistence

@command @entityFramework
Scenario: Create a new business via Entity Framework
	Given A new Business has been created
	When the Business does not exist in persistence by key
		And Business is inserted via Entity Framework
	Then the new business can be queried by key