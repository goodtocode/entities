@getUserCourseQueryV1
Feature: Get Learner Course Detail Query V1
As an learner
I am able to get my learner course detail

Scenario: Get Learner Course Detail returns a successful response
	Given I have a learnerKey and the learner exists
	And I have an externalCourseId and the learner course exists
	When I get the Learner Course detail
	Then Then the response is successful
	And The response contains a LearnerCourseKey
	And The response contains a CourseProductKey
	And The response contains a ExternalCourseKey
	And The response contains a Title
	And The response contains a Category
	And The response contains a EstimatedTimeToCompleteMinutes
	And The response contains a AccessExpirationDate
	And The response contains a UserCes
	And The response contains a PercentComplete
	And The response contains a AccessStatus
	And The response contains a ProgressStatus
	And The response contains a Documents
	And The response contains a CEStatementTitle
	And The response contains a CEStatementText

	And the response contains a collection of UserCes
	And each UserCe has a Title
	And each UserCe has a CEsISComplete
	And each UserCe has a CEsAvailable
	And each UserCe has a CerpAComplete
	And each UserCe has a CerpIsAvailable
	And each UserCe has a CerpBComplete
	And each UserCe has a CerpBIsAvailable
	And each UserCe has a CerpCComplete
	And each UserCe has a CerpIsCAvailable
	And each UserCe has a PharmaComplete
	And each UserCe has a PharmaAvailable
	And each UserCe has a GetCEUrl
	And each UserCe has a AssociatedScoComplete
	And each UserCe has a CeIsCompete
	And each UserCe has a CeExpirationDate
	And The response contains a PercentComplete
	And The response contains a AccessStatus
	#Access Status can be Available,  Expired, Sunset, Cancelled
	And The response contains a ProgressStatus
	#Progress Status can be NotStarted, Started, or Complete
	
	And The response contains a UserCourseUrl
	And the UserCourseUrl has a collection of documents Documents
	And each document has a Name
	And each document has a Description
	And each document has a DownloadUrl
	And each document has a Type
 	And The response contains a CEStatementTitle
	And The response contains a CEStatementText

Scenario: Get Learner Course Detail when course does not exist returns a not found
	Given I have a learnerKey and the learner exists
	And I have an externaCourseId and the course does NOT exist
	When I get the Learner Course detail
	Then Then the response tells me the User Course is not found
	
Scenario: Get Learner Course Detail with an empty reqired params returns a bad request
	Given I have an empty learnerKey
	And I have an empty externaCourseId
	And I have a empty courseId
	When I get the Learner Course detail
	Then Then the response tells me I made a bad request
	And The response errors tell me the customerKey is required
	And The response errors tell me the externaCourseId is required
	And The response errors tell me the courseId is required

	
#COA 10/12/22
