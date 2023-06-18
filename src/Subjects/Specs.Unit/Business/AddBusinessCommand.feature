@addBusinessCommand
Feature: Add Business Command
As an customer service agent
When I add business information
The business is saved in system of record

Scenario: Add business
	Given I have a def "<def>"
	And I have a BusinessName "<requestBusinessName>"	
	And I have a TaxNumber "<requestTaxNumber>"	
	When I add the business
	Then The response is "<response>"
	And If the response has validation issues I see the "<responseErrors>" in the response

Examples:
	| def									| response   | responseErrors                                   | requestBusinessName		| requestTaxNumber	|
	| success TaxNumber Add					| Success    |                                                  | businessName				| 123-4567			|
	| success Name Add						| Success    |                                                  | businessName				| 123-4567			|	
	| bad request Missing BusinessName		| BadRequest | BusinessName	                                    | 							| 123-4567			|