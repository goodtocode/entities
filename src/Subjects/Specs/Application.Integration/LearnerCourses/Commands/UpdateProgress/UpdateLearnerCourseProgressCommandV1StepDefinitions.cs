//using FluentAssertions;
//using FluentValidation.Results;
//using TechTalk.SpecFlow;

//namespace Goodtocode.Application.Integration.LearnerCourses.Commands.UpdateProgress
//{
//    [Binding]
//    public class UpdateLearnerCourseProgressCommandV1StepDefinitions : TestBase
//    {
//        private string _registrationID;
//        private string _externalCourseId;
//        private Guid _learnerCourseKey;
//        private UpdateLearnerCourseProgressCommand request;
//        private string _xApiRegistrationID;
//        private string _environmentName;
//        private Guid _learnerKey;
//        private DateTime _updatedDate;
//        private Course _course;
//        private CourseSco? _courseSco;
//        private LearnerCourse? _learnerCourse;
//        private LearnerCourseSco? _learnerCourseSco;
//        private string _registrationCompletion;
//        private double _registrationCompletionAmount;
//        private double _totalSecondsTracked;
//        private string _registrationSuccess;
//        private DateTime _firstAccessedDate;
//        private DateTime _createdDate;
//        private double _completionAmountScaled;
//        private Learner _learner;
//        private bool _activityDetailExists;
//        private ResponseType _responseType;
//        private IDictionary<string, string[]> _handlerErrors;
//        private List<ValidationFailure> _validationErrors = new List<ValidationFailure>();
//        private string _courseTitle;
//        private int _courseVersion;
//        private bool _learnerExists;
//        private bool _courseExists;
//        private string _learnerFirstName;
//        private string _activityDetailId;
//        private string _activityDetailTitle;
//        private int _activityDetailAttempts;
//        private string _activityDetailCompletion;
//        private string _activityDetailSuccess;
//        private string _activityDetailTimeTracked;
//        private double _activityDetailCompletionAmount;
//        private bool _activityDetailHasChildren;
//        private string _activityDetailChildId;
//        private string _activityDetailChildTitle;
//        private int _activityDetailChildAttempts;
//        private string _activityDetailChildActivityCompletion;
//        private string _activityDetailChildActivitySuccess;
//        private string _activityDetailChildTimeTracked;
//        private double _activityDetailChildCompletionAmountScaled;
//        private bool _completionAmountHasScaled;
//        private bool _activityDetailChildHasChildren;
//        private bool _completionAmountChildCompletionAmountHasScaled;

//        [Given(@"I have multiple in-progress course scos")]
//        public async Task GivenIHaveMultipleIn_ProgressCourseScos()
//        {
//            _learnerCourseSco = await FirstOrDefaultAsync<Courses.Core.Domain.LearnerCourseScos.Entities.LearnerCourseSco>(x =>
//                x.CompletionStatus != "Completed" && x.CompletionStatus != "Satisfied" && x.DeleteFlag == 0x00);
//            _learnerCourse = await FirstOrDefaultAsync<Courses.Core.Domain.LearnerCourses.Entities.LearnerCourse>(x =>
//                x.Key == _learnerCourseSco.LearnerCourseKey);
//            _course = await FirstOrDefaultAsync<Courses.Core.Domain.Courses.Entities.Course>(x =>
//                x.Key == _learnerCourse.CourseKey);
//            _courseSco = await FirstOrDefaultAsync<Courses.Core.Domain.CourseScos.Entities.CourseSco>(x =>
//                x.Key == _learnerCourseSco.CourseScoKey);
//        }

//        [Given(@"I have one in-progress course scos")]
//        public async Task GivenIHaveOneIn_ProgressCourseScos()
//        {
//            _learnerCourseSco = await FirstOrDefaultAsync<Courses.Core.Domain.LearnerCourseScos.Entities.LearnerCourseSco>(x =>
//                x.CompletionStatus != "Completed" && x.CompletionStatus != "Satisfied" && x.DeleteFlag == 0x00);
//            _learnerCourse = await FirstOrDefaultAsync<Courses.Core.Domain.LearnerCourses.Entities.LearnerCourse>(x =>
//                x.Key == _learnerCourseSco.LearnerCourseKey);
//            _course = await FirstOrDefaultAsync<Courses.Core.Domain.Courses.Entities.Course>(x =>
//                x.Key == _learnerCourse.CourseKey);
//            _courseSco = await FirstOrDefaultAsync<Courses.Core.Domain.CourseScos.Entities.CourseSco>(x =>
//                x.Key == _learnerCourseSco.CourseScoKey);
//        }

//        [Given(@"I have a registrationId")]
//        public void GivenIHaveARegistrationId()
//        {
//            _externalCourseId = _course.ExternalId;
//            _learnerKey = _learnerCourse.CstKey;
//            _registrationID = GetRegistrationId("Local", _learnerKey.ToString(), _externalCourseId);
//        }

//        [Given(@"I have a xapiRegistrationId")]
//        public void GivenIHaveAXapiRegistrationId()
//        {
//            _xApiRegistrationID = Guid.NewGuid().ToString();
//        }

//        [Given(@"I have a updatedDate")]
//        public void GivenIHaveAUpdatedDate()
//        {
//            _updatedDate = DateTime.Now;
//        }

//        [Given(@"I have an INCOMPLETE registrationCompletion")]
//        public void GivenIHaveAIncompleteRegistrationCompletion()
//        {
//            _registrationCompletion = "INCOMPLETE";
//        }

//        [Given(@"I have an COMPLETED registrationCompletion")]
//        public void GivenIHaveACompletedRegistrationCompletion()
//        {
//            _registrationCompletion = "COMPLETED";
//        }

//        [Given(@"I have a registrationCompletionAmount")]
//        public void GivenIHaveARegistrationCompletionAmount()
//        {
//            _registrationCompletionAmount = 0.2705098;
//        }

//        [Given(@"I have a totalSecondsTracked")]
//        public void GivenIHaveATotalSecondsTracked()
//        {
//            _totalSecondsTracked = 2186715.0;
//        }

//        [Given(@"I have a UNKNOWN registrationSuccess")]
//        public void GivenIHaveAUnknownRegistrationSuccess()
//        {
//            _registrationSuccess = "UNKNOWN";
//        }

//        [Given(@"I have a FAILED registrationSuccess")]
//        public void GivenIHaveAFailedRegistrationSuccess()
//        {
//            _registrationSuccess = "FAILED";
//        }

//        [Given(@"I have a firstAccessDate")]
//        public void GivenIHaveAFirstAccessDate()
//        {
//            _firstAccessedDate = DateTime.Now.AddDays(-5);
//        }

//        [Given(@"I have a createdDate")]
//        public void GivenIHaveACreatedDate()
//        {
//            _createdDate = DateTime.Now;
//        }

//        [Given(@"I have a course")]
//        public void GivenIHaveACourse()
//        {
//            _courseExists = true;
//        }

//        [Given(@"The course has an id")]
//        public void GivenTheCourseHasAnId()
//        {                        
//            _learnerCourseKey = _learnerCourse.Key;
//        }

//        [Given(@"The course has a title")]
//        public void GivenTheCourseHasATitle()
//        {
//            _courseTitle = _course.ShortTitle;
//        }

//        [Given(@"The course has a version")]
//        public void GivenTheCourseHasAVersion()
//        {
//            _courseVersion = 0;
//        }

//        [Given(@"I have a learner")]
//        public void GivenIHaveALearner()
//        {
//            _learnerExists = true;
//        }

//        [Given(@"The learner has an id")]
//        public void GivenTheLearnerHasAnId()
//        {
//            _learnerKey = _learnerCourse.CstKey;
//        }

//        [Given(@"The learner has a firstName")]
//        public void GivenTheLearnerHasAFirstName()
//        {
//            _learnerFirstName = "Joe";
//        }

//        [Given(@"I have a collection tags")]
//        public void GivenIHaveACollectionTags()
//        {
//            // Not supported
//        }

//        [Given(@"I have an activity detail")]
//        public void GivenIHaveAnActivityDetail()
//        {
//            _activityDetailExists = true;
//        }

//        [Given(@"The activity detail has an id")]
//        public void GivenTheActivityDetailHasAnId()
//        {
//            _activityDetailId = "ORG-PLS-PRO-1001-EPCCO-5.0"; // Is this in netforum?
//        }

//        [Given(@"The activity detail has an title")]
//        public void GivenTheActivityDetailHasAnTitle()
//        {
//            _activityDetailTitle = _courseTitle;
//        }

//        [Given(@"The activity detail has an attempts")]
//        public void GivenTheActivityDetailHasAnAttempts()
//        {
//            _activityDetailAttempts = 1;
//        }

//        [Given(@"The activity detail has an INCOMPLETE activityCompletion")]
//        public void GivenTheActivityDetailHasAnIncompleteActivityCompletion()
//        {
//            _activityDetailCompletion = "INCOMPLETE";
//        }

//        [Given(@"The activity detail has an COMPLETED activityCompletion")]
//        public void GivenTheActivityDetailHasAnCompletedActivityCompletion()
//        {
//            _activityDetailCompletion = "COMPLETED";
//        }

//        [Given(@"The activity detail has an UNKNOWN activitySuccess")]
//        public void GivenTheActivityDetailHasAnUnknownActivitySuccess()
//        {
//            _activityDetailSuccess = "UNKNOWN";
//        }

//        [Given(@"The activity detail has an FAILED activitySuccess")]
//        public void GivenTheActivityDetailHasAnFailedActivitySuccess()
//        {
//            _activityDetailSuccess = "FAILED";
//        }

//        [Given(@"The activity detail has an timeTracked")]
//        public void GivenTheActivityDetailHasAnTimeTracked()
//        {
//            _activityDetailTimeTracked = "0000:00:00";
//        }

//        [Given(@"I have a completionAmount")]
//        public void GivenIHaveACompletionAmount()
//        {
//            _activityDetailCompletionAmount = 0.2705098;
//        }

//        [Given(@"The completionAmount has a scaled")]
//        public void GivenTheCompletionAmountHasAScaled()
//        {
//            _completionAmountHasScaled = true;
//        }

//        [Given(@"The activity detail has a collection of children")]
//        public void GivenTheActivityDetailHasACollectionOfChildren()
//        {
//            _activityDetailHasChildren = true;
//        }

//        [Given(@"each activity detail child has a id")]
//        public void GivenEachActivityDetailChildHasAId()
//        {
//            _activityDetailChildId = _courseSco.ExternalId;
//        }

//        [Given(@"each activity detail child has a title")]
//        public void GivenEachActivityDetailChildHasATitle()
//        {
//            _activityDetailChildTitle = _courseSco.Title;
//        }

//        [Given(@"each activity detail child has a attempts")]
//        public void GivenEachActivityDetailChildHasAAttempts()
//        {
//            _activityDetailChildAttempts = 0;
//        }

//        [Given(@"each activity detail child has a INCOMPLETE activityCompletion")]
//        public void GivenEachActivityDetailChildHasAIncompleteActivityCompletion()
//        {
//            _activityDetailChildActivityCompletion = "INCOMPLETE";
//        }

//        [Given(@"each activity detail child has a COMPLETED activityCompletion")]
//        public void GivenEachActivityDetailChildHasAActivityCompletion()
//        {
//            _activityDetailChildActivityCompletion = "COMPLETED";
//        }


//        [Given(@"each activity detail child has a UNKNOWN activitySuccess")]
//        public void GivenEachActivityDetailChildHasAUnknownActivitySuccess()
//        {
//            _activityDetailChildActivitySuccess = "UNKNOWN";
//        }

//        [Given(@"each activity detail child has a FAILED activitySuccess")]
//        public void GivenEachActivityDetailChildHasAFailedActivitySuccess()
//        {
//            _activityDetailChildActivitySuccess = "FAILED";
//        }

//        [Given(@"each activity detail child has a PASSED activitySuccess")]
//        public void GivenEachActivityDetailChildHasAPassedActivitySuccess()
//        {
//            _activityDetailChildActivitySuccess = "PASSED";
//        }

//        [Given(@"each activity detail child has a timeTracked")]
//        public void GivenEachActivityDetailChildHasATimeTracked()
//        {
//            _activityDetailChildTimeTracked = "0000:00:00";
//        }

//        [Given(@"each activity detail child has a completionAmount")]
//        public void GivenEachActivityDetailChildHasACompletionAmount()
//        {
//            _activityDetailChildCompletionAmountScaled = 0.2366667;
//        }

//        [Given(@"the activity detail child completionAmount has ascaled")]
//        public void GivenTheActivityDetailChildCompletionAmountHasAscaled()
//        {
//            _completionAmountChildCompletionAmountHasScaled = true;
//        }

//        [Given(@"each activity detail has a collection of children RECURSIVE")]
//        public void GivenEachActivityDetailHasACollectionOfChildrenRECURSIVE()
//        {
//            _activityDetailChildHasChildren = true;
//        }

//        [When(@"I update the user course progress")]
//        public async Task WhenIUpdateTheUserCourseProgress()
//        {
//            SetupTestDoubles();

//            var validator = new UpdateLearnerCourseProgressCommandValidator();
//            var validationResult = validator.Validate(request);

//            if (validationResult.IsValid)
//            {
//                try
//                {
//                    await SendAsync(request);
//                    _responseType = TestBase.ResponseType.Successful;
//                }
//                catch (Exception e)
//                {
//                    if (e is NotFoundException notFoundException)
//                    {
//                        _responseType = ResponseType.NotFound;
//                    }
//                    else if (e is ValidationException validationException)
//                    {
//                        _responseType = ResponseType.BadRequest;
//                        _handlerErrors = validationException.Errors;
//                    }

//                    else
//                    {
//                        _responseType = ResponseType.Error;
//                    }
//                }
//            }
//            else
//            {
//                _responseType = ResponseType.BadRequest;
//                _validationErrors = validationResult.Errors;
//            }
//        }

//        [Then(@"The response is successful")]
//        public void ThenTheResponseIsSuccessful()
//        {
//            _responseType.Should().Be(ResponseType.Successful);
//        }

//        private void SetupTestDoubles()
//        {
//            request = new UpdateLearnerCourseProgressCommand()
//            {
//                id = _registrationID,
//                updated = DateTime.UtcNow,
//                registrationCompletion = _registrationCompletion,
//                registrationCompletionAmount = _registrationCompletionAmount,
//                totalSecondsTracked = _totalSecondsTracked,
//                registrationSuccess = _registrationSuccess,
//                firstAccessDate = DateTime.UtcNow,
//                createdDate = DateTime.UtcNow
//            };
//            request.course = new Courses.Core.Application.LearnerCourses.Commands.UpdateLearnerCourseProgress.Dtos.Course()
//            {
//                id = _externalCourseId,
//                title = _courseTitle,
//                version = _courseVersion
//            };
//            request.learner = new Learner()
//            {
//                id = _learnerKey.ToString(),
//                email = "test@org",
//                firstName = _learnerFirstName,
//                lastName = "Doe"
//            };
//            request.activityDetails = new ActivityDetails()
//            {
//                id = _activityDetailId,
//                attempts = 1,
//                title = _courseTitle,
//                activityCompletion = _activityDetailCompletion,
//                activitySuccess = _activityDetailSuccess,
//                timeTracked = _activityDetailTimeTracked,
//                completionAmount = new CompletionAmount()
//                {
//                    scaled = 0.2705098
//                }
//            };
//            request.activityDetails.children = new List<Child>() { new Child()
//            {
//                id = _activityDetailChildId,
//                attempts = 1,
//                title = _activityDetailTitle,
//                activityCompletion = _activityDetailChildActivityCompletion,
//                activitySuccess = _activityDetailChildActivitySuccess,
//                timeTracked = "0000:00:00",
//                completionAmount = new CompletionAmount()
//                {
//                    scaled = _activityDetailChildCompletionAmountScaled
//                },
//                children = new List<Child>() { new Child()
//                {
//                    id = "ITEM-ECCO4-M01-1-1-PCU_SCO",
//                    attempts = 1,
//                    title = "Professional Progressive Care Nursing Practice - PCU",
//                    activityCompletion = _activityDetailCompletion,
//                    activitySuccess = _activityDetailSuccess,
//                    timeTracked = "0000:53:35.24",
//                    completionAmount = new CompletionAmount()
//                    {
//                        scaled = 0.31
//                    }
//                }
//            }}};
//        }

//        protected static string GetRegistrationId(string environmentName, string learnerKey, string externalCourseId)
//        {
//            return $"{environmentName}_{learnerKey}.{externalCourseId}";
//        }
//    }
//}
