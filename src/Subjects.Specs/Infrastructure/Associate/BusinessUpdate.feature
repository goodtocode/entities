Feature: Business Update
	Update a new business into persistence

@crud @entityFramework
Scenario: Update a new business via Entity Framework
	Given An existing Business has been queried
		And a business was found in persistence
	When the Business name changes
		And Business is Updated via Entity Framework
	Then the existing business can be queried by key
		And the Business name matches the new name