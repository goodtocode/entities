@deleteBusinessCommand
Feature: Delete Business Command
As an customer service agent
I delete the business
The business is deleted from the system of record

Scenario: Delete business
	Given I have a def "<def>"
	And I have a BusinessKey "<requestBusinessKey>"
	When I delete the business
	Then The response is "<response>"
	And If the response has validation issues I see the "<responseErrors>" in the response

Examples:
	| def								| response		| responseErrors                        | requestBusinessKey					|
	| success TaxNumber BusinessKey		| Success		|                                       | 038213ba-9d95-42f3-8e8b-126cec10481b  |
	| not found BusinessKey				| NotFound		|										| 038213ba-9d95-42f3-8e8b-126cec10481b	|
	| bad request Empty BusinessKey		| BadRequest	| BusinessKey							| 00000000-0000-0000-0000-000000000000	|
	| bad request non-guid BusinessKey	| BadRequest	| BusinessKey							| 11111									|