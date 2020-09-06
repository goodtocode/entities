Feature: Fn Business Update
	Update a new business into persistence

@command @azureFunction
Scenario: Update an existing business via Azure Function
	Given I have an non empty business key for the Azure Function
		And the business name is provided for the Azure Function
	When Business is posted via Azure Function
	Then the business is updated in persistence when queried from Azure Function