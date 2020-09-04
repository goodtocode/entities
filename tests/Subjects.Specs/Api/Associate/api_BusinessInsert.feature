Feature: Business Insert
	Insert a new business into persistence

@command @azureFunction
Scenario: Insert a new business via Web API
	Given I have an empty business key for Web API
		And the business name is provided for Web API
	When Business is Post via Web API
	Then the business is inserted to persistence via Web API
