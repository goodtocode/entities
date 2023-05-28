//using Courses.Core.Application.Common.Exceptions;
//using Courses.Core.Application.LearnerCourses.Queries.GetLaunchUrl;
//using FluentAssertions;
//using FluentValidation.Results;
//using System.Collections.Concurrent;
//using TechTalk.SpecFlow;

//namespace Goodtocode.Application.Integration.LearnerCourses.Queries.GetLaunchUrl;

//[Binding]
//[Scope(Tag = "getLearnerCourseLaunchUrlQueryV1")]
//public class GetLearnerCourselLaunchUrlV1StepDefinitions : TestBase
//{
//    private IDictionary<string, string[]> _handlerErrors = new ConcurrentDictionary<string, string[]>();
//    private bool _courseExists;
//    private string _courseId;
//    private string _firstName;
//    private string _lastName;
//    private bool _learnerIsRegistered;
//    private Guid _learnerKey;
//    private string _response;
//    private TestBase.ResponseType _responseType;
//    private List<ValidationFailure> _validationErrors = new();

//    [Given(@"I have a learnerKey")]
//    public void GivenIHaveALearnerKey()
//    {
//        _learnerKey = Guid.Parse("ad790f32-f501-4838-8e4a-c1b057c44f30");
//    }

//    [Given(@"I have an unregistered learner key")]
//    public void GivenIHaveAnUnregisteredLearnerKey()
//    {
//        _learnerKey = Guid.NewGuid();
//    }

//    [Given(@"The learner is registered")]
//    public void GivenTheUserIsRegistered()
//    {
//        _learnerIsRegistered = true;
//    }


//    [Given(@"I have an external course Id")]
//    public void GivenIHaveAnExternalCourseId()
//    {
//        _courseId = "z_FSNM_m01_01_JobDesc";
//    }

//    [Given(@"I have an Invald external course Id")]
//    public void GivenIHaveAnInvaldExternalCourseId()
//    {
//        _courseId = "INVALID_KEY";
//    }
    
//    [Given(@"the course exists")]
//    public void GivenTheCourseExists()
//    {
//        _courseExists = true;
//    }

//    [Given(@"I have a firstName")]
//    public void GivenIHaveAFirstName()
//    {
//        _firstName = "Erik";
//    }

//    [Given(@"I have a lastName")]
//    public void GivenIHaveALastName()
//    {
//        _lastName = "Chris";
//    }
    
//    [When(@"I have a firstName")]
//    public void WhenIHaveAFirstName()
//    {
//        _firstName = "Erik";
//    }

 
//    [Given(@"I have an empty firstName")]
//    public void GivenIHaveAnEmptyFirstName()
//    {
//        _firstName = string.Empty;
//    }

//    [Given(@"I have a empty lastName")]
//    public void GivenIHaveAEmptyLastName()
//    {
//        _lastName = string.Empty;
//    }


//    [When(@"I get the launch url")]
//    public async Task WhenIGetTheLaunchUrl()
//    {
        
//        var request = new GetCoursesLaunchUrlQuery
//        {
//            LearnerKey = _learnerKey,
//            ExternalCourseId = _courseId,
//            FirstName = _firstName,
//            LastName = _lastName
//        };
        
//        var validator = new GetCoursesLaunchUrlQueryValidator();
//        var requestValidation = validator.Validate(request);

//        if (requestValidation.IsValid)
//        {
//            try
//            {
//                _response = await SendAsync(request);
//                _responseType = TestBase.ResponseType.Successful;
//            }
//            catch (Exception e)
//            {
//                switch (e)
//                {
//                    case ValidationException validationException:
//                        _handlerErrors = validationException.Errors;
//                        _responseType = TestBase.ResponseType.BadRequest;
//                        break;
//                    case NotFoundException notFoundException:
//                        _responseType = TestBase.ResponseType.NotFound;
//                        break;
//                    default:
//                        _responseType = TestBase.ResponseType.Error;
//                        break;
//                }
//            }
//        }
//        else
//        {
//            _validationErrors = requestValidation.Errors;
//            _responseType = TestBase.ResponseType.BadRequest;
//        }
//    }

//    [Then(@"The response is successful")]
//    public void ThenTheResponseIsSuccessful()
//    {
//        _responseType.Should().Be(TestBase.ResponseType.Successful);
//    }

//    [Then(@"The response contains a launch url")]
//    public void ThenTheResponseContainsALaunchUrl()
//    {
//        _response.Should().NotBeNullOrWhiteSpace();
//    }

//    [Given(@"the course does not exist")]
//    public void GivenTheCourseDoesNotExist()
//    {
//        _courseExists = false;
//    }

//    [Then(@"The response tells me the Learner Course is not found")]
//    public void ThenTheResponseTellsMeTheLearnerCourseIsNotFound()
//    {
//        _responseType.Should().Be(TestBase.ResponseType.NotFound);
//    }

//    [Given(@"The learner is not registered")]
//    public void GivenTheLearnerIsNotRegistered()
//    {
//        _learnerIsRegistered = false;
//    }


//    [Given(@"I have an empty learnerKey")]
//    public void GivenIHaveAnEmptyLearnerKey()
//    {
//        _learnerKey = Guid.Empty;
//    }

//    [Given(@"I have an empty external course Id")]
//    public void GivenIHaveAnEmptyExternalCourseId()
//    {
//        _courseId = string.Empty;
//    }

//    [Then(@"The response is tells me I made a bad request")]
//    public void ThenTheResponseIsTellsMeIMadeABadRequest()
//    {
//        _responseType.Should().Be(TestBase.ResponseType.BadRequest);
//    }

//    [Then(@"The response errors tell me the learnerKey is required")]
//    public void ThenTheResponseErrorsTellMeTheLearnerKeyIsRequired()
//    {
//        _validationErrors.Any(x => x.PropertyName == "LearnerKey").Should().BeTrue();
//    }

//    [Then(@"The response errors tell me the empty params are required")]
//    public void ThenTheResponseErrorsTellMeTheExternalCourseIdIsRequired()
//    {
//        _validationErrors.Any(x => x.PropertyName == "LearnerKey").Should().BeTrue();
//        _validationErrors.Any(x => x.PropertyName == "ExternalCourseId").Should().BeTrue();
//        _validationErrors.Any(x => x.PropertyName == "FirstName").Should().BeTrue();
//        _validationErrors.Any(x => x.PropertyName == "LastName").Should().BeTrue();
//    }
//}

