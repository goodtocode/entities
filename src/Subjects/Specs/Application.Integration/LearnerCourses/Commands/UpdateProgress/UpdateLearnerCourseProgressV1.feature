@updateLearnerCourseProgressCommandV1
Feature: Update Learner Course Progress Command V1
As the SCORM system
I am able to update AACN regarding a Learner Course Progress

Scenario: Update Learner Course Progress passes one, but not all, Sco tests
	Given I have multiple in-progress course scos
	And I have a registrationId
	And I have a xapiRegistrationId
	And I have a updatedDate
	And I have an INCOMPLETE registrationCompletion
	And I have a registrationCompletionAmount
	And I have a totalSecondsTracked
	And I have a UNKNOWN registrationSuccess
	And I have a firstAccessDate
	And I have a createdDate
	And I have a course
	And The course has an id
	And The course has a title
	And The course has a version
	And I have a learner
	And The learner has an id
	And The learner has a firstName
	And I have a collection tags
	And I have an activity detail
	And The activity detail has an id
	And The activity detail has an title
	And The activity detail has an attempts
	And The activity detail has an INCOMPLETE activityCompletion
	And The activity detail has an UNKNOWN activitySuccess
	And The activity detail has an timeTracked
	And I have a completionAmount
	And The completionAmount has a scaled
	And The activity detail has a collection of children
	And each activity detail child has a id
	And each activity detail child has a title
	And each activity detail child has a attempts
	And each activity detail child has a COMPLETED activityCompletion
	And each activity detail child has a PASSED activitySuccess
	And each activity detail child has a timeTracked
	And each activity detail child has a completionAmount
	And the activity detail child completionAmount has ascaled
	And each activity detail has a collection of children RECURSIVE
	When I update the user course progress
	Then The response is successful
#
#Scenario: Learner fails a Sco test
#	Given I have multiple in-progress course scos
#	And I have a registrationId
#	And I have a xapiRegistrationId
#	And I have a updatedDate
#	And I have an COMPLETED registrationCompletion
#	And I have a registrationCompletionAmount
#	And I have a totalSecondsTracked
#	And I have a FAILED registrationSuccess
#	And I have a firstAccessDate
#	And I have a createdDate
#	And I have a course
#	And The course has an id
#	And The course has a title
#	And The course has a version
#	And I have a learner
#	And The learner has an id
#	And The learner has a firstName
#	And I have a collection tags
#	And I have an activity detail
#	And The activity detail has an id
#	And The activity detail has an title
#	And The activity detail has an attempts
#	And The activity detail has an COMPLETED activityCompletion
#	And The activity detail has an FAILED activitySuccess
#	And The activity detail has an timeTracked
#	And I have a completionAmount
#	And The completionAmount has a scaled
#	And The activity detail has a collection of children
#	And each activity detail child has a id
#	And each activity detail child has a title
#	And each activity detail child has a attempts
#	And each activity detail child has a COMPLETED activityCompletion
#	And each activity detail child has a PASSED activitySuccess
#	And each activity detail child has a timeTracked
#	And each activity detail child has a completionAmount
#	And the activity detail child completionAmount has ascaled
#	And each activity detail has a collection of children RECURSIVE
#	When I update the user course progress
#	Then The response is successful
#
#Scenario: Learner passes all Sco tests
#	Given I have one in-progress course scos
#	And I have a registrationId
#	And I have a xapiRegistrationId
#	And I have a updatedDate
#	And I have an COMPLETED registrationCompletion
#	And I have a registrationCompletionAmount
#	And I have a totalSecondsTracked
#	And I have a FAILED registrationSuccess
#	And I have a firstAccessDate
#	And I have a createdDate
#	And I have a course
#	And The course has an id
#	And The course has a title
#	And The course has a version
#	And I have a learner
#	And The learner has an id
#	And The learner has a firstName
#	And I have a collection tags
#	And I have an activity detail
#	And The activity detail has an id
#	And The activity detail has an title
#	And The activity detail has an attempts
#	And The activity detail has an COMPLETED activityCompletion
#	And The activity detail has an FAILED activitySuccess
#	And The activity detail has an timeTracked
#	And I have a completionAmount
#	And The completionAmount has a scaled
#	And The activity detail has a collection of children
#	And each activity detail child has a id
#	And each activity detail child has a title
#	And each activity detail child has a attempts
#	And each activity detail child has a COMPLETED activityCompletion
#	And each activity detail child has a PASSED activitySuccess
#	And each activity detail child has a timeTracked
#	And each activity detail child has a completionAmount
#	And the activity detail child completionAmount has ascaled
#	And each activity detail has a collection of children RECURSIVE
#	When I update the user course progress
#	Then The response is successful
#
#Scenario: Learner views course but does not pass all tests
