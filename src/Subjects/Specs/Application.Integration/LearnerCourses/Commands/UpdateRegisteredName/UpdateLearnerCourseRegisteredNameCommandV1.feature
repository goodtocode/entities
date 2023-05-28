@updateRegisteredNameCommandV1
Feature: Update Learner Registered Name Command V1
As an Aacn System
I am able to update the course registared user name

Scenario: Update Learner Course Registered Name returns a successful response
	Given I have a learnerKey And The learner exists
	And I have a learners firstName
	And I have a learners lastName
	When I update the Learner Course Registered Name
	Then The response is successful

Scenario: Update Learner Course Registered Name when user is not registered for course returns not found
	Given I have a learnerKey and the learner does not exist	
	And I have a learners firstName
	And I have a learners lastName
	When I update the Learner Course Registered Name
	Then The response tells me the Learner Course does not found

Scenario: Update Learner Course Registered Name with empty required properties returns a bad request
	Given I have an empty learnerKey
	And I have an empty learners firstName
	And I have an empty learners lastName
	When I update the Learner Course Registered Name
	Then The response tells me I mad a bad request
	And The response validation errors tell me the learners firstName is required
	And The response validation errors tell me the learners lastName is required
	And The response validation errors tell me the learnerKey is required

#COA 10/7/22
