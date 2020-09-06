Feature: Schedule Aggregate
	Recommended method of changing any Assiciate namespaced data

@aggregate
Scenario: Save a new Schedule via Aggregate
	Given A new Schedule is created for the aggregate
	When the Schedule does not exist in persistence 
		And the Schedule is saved via the aggregate
	Then the aggregate inserted Schedule can be queried by key