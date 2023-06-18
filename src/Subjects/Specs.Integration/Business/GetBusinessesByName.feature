@getBusinessesByName
Feature: Find Businesses by name
	As a customer service rep
	When I search for a business by name critera
	I can see a list of businesses that match the name criteria

Scenario: Get Existing Business By Name
	Given I have a def "<def>"
	And I have a BusinessName "<businessName>"
	And the business exists "<businessExists>"
	When I query for matching Businesses
	Then the response is "<response>"
	And if the response has validation issues I see the "<responseErrors>" in the response
	And if the response is valid then the response contains a collection of businesses
	And each business has a matching BusinessName of "<businessName>"

Examples:
	| def                | response   | responseErrors | businessName | businessExists |
	| success exists     | Success    |                | BusinessInDb | true           |
	| empty name         | BadRequest | BusinessName   |              | false          |