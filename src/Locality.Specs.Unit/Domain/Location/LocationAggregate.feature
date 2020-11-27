Feature: Location Aggregate
	Recommended method of changing any Assiciate namespaced data

@aggregate
Scenario: Save a new Location via Aggregate
	Given A new Location is created for the aggregate
	When the Location does not exist in persistence 
		And the Location is saved via the aggregate
	Then the aggregate inserted Location can be queried by key