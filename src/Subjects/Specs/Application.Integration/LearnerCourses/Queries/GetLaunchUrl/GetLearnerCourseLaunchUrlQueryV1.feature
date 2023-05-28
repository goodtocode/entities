@getLearnerCourseLaunchUrlQueryV1
Feature: Get Learner Coursel Launch Url V1
As an learner
I am able to get my course launch url

Scenario: Get Learner Course Launch Url returns a successful response
	Given I have a learnerKey
	And The learner is registered
	And I have an external course Id
	And I have a firstName
	And I have a lastName
	And the course exists
	When I get the launch url
	Then The response is successful
	And The response contains a launch url

Scenario: Get Learner Course Launch Url when learner not registered returns a successful response
	Given I have an unregistered learner key
	And I have an external course Id
	And I have a firstName
	And I have a lastName
	And the course exists
	When I get the launch url
	Then The response is successful
	And The response contains a launch url

Scenario: Get Learner Course Launch Url when course does not exist
	Given I have a learnerKey
	And The learner is registered
	And I have an Invald external course Id
	And I have a firstName
	And I have a lastName
	When I get the launch url
	Then The response tells me the Learner Course is not found

Scenario: Get Learner Course Launch Url with empty required params returns a bad request
	Given I have an empty learnerKey
	And I have an empty external course Id
	And I have an empty firstName
	And I have a empty lastName
	When I get the launch url
	Then The response is tells me I made a bad request
	And The response errors tell me the empty params are required

	#COA 10/7/22