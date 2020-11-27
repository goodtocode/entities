Feature: Schedule Create
	Create a new Schedule in persistence

@crud @entityFramework
Scenario: Create a new Schedule via Entity Framework
	Given A new Schedule has been created
	When the Schedule does not exist in persistence by key
		And Schedule is inserted via Entity Framework
	Then the new Schedule can be queried by key