Feature: Business Delete
	Delete a business from persistence

@crud @entityFramework
Scenario: Delete an existing business via Entity Framework
	Given An Business has been queried to be deleted
		And a business to be deleted was found in persistence
	When the Business is Deleted via Entity Framework
	Then the deleted business is queried by key
		And the Business is not found