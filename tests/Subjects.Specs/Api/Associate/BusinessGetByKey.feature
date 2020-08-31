Feature: Business Get by Key from Web API
	Get a Business from Web API

@query @azureFunction
Scenario: Get a business by key via Web API
	Given I have a business key from Web API
	When Business is Get by key via Web API
		And the business exists in Web API
	Then the matching business is returned from Web API
