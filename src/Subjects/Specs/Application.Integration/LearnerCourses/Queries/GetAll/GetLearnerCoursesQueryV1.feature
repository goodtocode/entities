@getAllLearnerCoursesQueryV1
Feature: Get Learner Courses Query V1
As a Learner
I am able to get all my courses

Scenario: Get Learner Courses when learner exists returns a successful response
	Given I have a Learner Key and learner courses exist
	When I get the Learner Courses
	Then The response is successful
	And The response contains a collection of LearnerCourses
	And Each LearnerCourse contains a ExternalCourseKey
	And Each LearnerCourse contains a ShortTitle
	And Each LearnerCourse contains a PercentComplete
	And Each LearnerCourse contains a AccessExpirationDate
	And Each LearnerCourse contains a CeHoursAvailable
	And Each LearnerCourse contains a CeHoursCompleted

Scenario: Get Learner Courses when learner does not exist returns an empty set of learner courses
	Given I have a Learner Key and learner has no courses
	When I get the Learner Courses
	Then Response contains an empty collection of learner courses

Scenario: Get Learner Courses with an empty learner key returns a bad request response
	Given I have an empty Learner Key
	When I get the Learner Courses
	Then The response is a bad request
	And  The response errors tells me the learner key is required