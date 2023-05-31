@updateBusinessCommand
Feature: Update Business Command
As an customer service agent
I can change business information
And get the system of record updated

Scenario: Update business
	Given I have a def "<def>"
	And I have a BusinessKey "<requestBusinessKey>"
	And I have a BusinessName "<requestBusinessName>"	
	And I have a TaxNumber "<requestTaxNumber>"	
	When I update the business
	Then The response is "<response>"
	And If the response has validation issues I see the "<responseErrors>" in the response

Examples:
	| def									| response   | responseErrors                                   | requestBusinessKey					| requestBusinessName	| requestTaxNumber	|
	| success TaxNumber Add					| Success    |                                                  | d1604a05-f883-40f1-803b-8562b5674f1a  | BizName				| 123-4567			|
	| success TaxNumber Update				| Success    |                                                  | d1604a05-f883-40f1-803b-8562b5674f1a  | BizName				| 123-4567			|
	| success TaxNumber Remove				| Success    |                                                  | d1604a05-f883-40f1-803b-8562b5674f1a  | BizName				| 					|
	| success Name Update					| Success    |                                                  | d1604a05-f883-40f1-803b-8562b5674f1a  | BizName				| 123-4567			|	
	| bad request Invalid BusinessKey		| BadRequest | BusinessKey										| 11111									| BizName				| 123-4567			|
	| bad request Invalid BusinessName		| BadRequest | BusinessName	                                    | d1604a05-f883-40f1-803b-8562b5674f1a  |						| 123-4567			|
	| bad request							| BadRequest | BusinessKey,BusinessName							| 11111									| 						| 					|