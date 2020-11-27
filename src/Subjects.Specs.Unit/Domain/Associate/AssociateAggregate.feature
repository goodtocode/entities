Feature: Associate Aggregate
	Recommended method of changing any Assiciate namespaced data

@aggregate
Scenario: Save a new business via Aggregate
	Given A new Business is created for the aggregate
		And the new business for the Aggregate is Serializable
	When the business does not exist in persistence 
		And the business is saved via the aggregate
	Then the aggregate inserted business can be queried by key