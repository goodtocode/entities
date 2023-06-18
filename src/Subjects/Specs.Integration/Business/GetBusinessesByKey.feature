@getBusinessesByKey
Feature: Find Businesses by key
	As a customer service rep
	When I search for a business by key critera
	I can see a exact match for a business

Scenario: Get Existing Business By Name
	Given I have a def "<def>"
	And I have a BusinessKey "<businessKey>"
	And the business exists "<businessExists>"
	When I query for matching Businesses
	Then the response is "<response>"
	And if the response has validation issues I see the "<responseErrors>" in the response
	And if the response is valid then the response contains a business
	And the business has a matching BusinessKey of "<businessKey>"

Examples:
	| def                | response   | responseErrors | businessKey							| businessExists |
	| success exists     | Success    |                | 2016a497-e56c-4be8-8ef6-3dc5ae1699ce	| true           |
	| Business NotFound  | NotFound   |                | 1234a497-1234-1234-8ef6-3dc5ae1699ce	| false          |
	| empty key          | BadRequest | BusinessKey    | 00000000-0000-0000-0000-000000000000	| false          |