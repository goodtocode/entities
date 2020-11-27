Feature: Business Create
	Create a new business in persistence

@crud @entityFramework
Scenario: Create a new business via Entity Framework
	Given A new Business has been created
		And the business to be created via Entity Framework is serializable
	When the Business does not exist in persistence by key
		And Business is inserted via Entity Framework
	Then the new business can be queried by key