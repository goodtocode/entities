Feature: Event Aggregate
	Recommended method of changing any Assiciate namespaced data

@aggregate
Scenario: Save a new Event via Aggregate
	Given A new Event is created for the aggregate
	When the Event does not exist in persistence 
		And the Event is saved via the aggregate
	Then the aggregate inserted Event can be queried by key