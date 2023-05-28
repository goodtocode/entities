//using Courses.Core.Application.Common.Exceptions;
//using Courses.Core.Application.Common.Interfaces;
//using Courses.Core.Application.LearnerCourses.Queries.GetAll;
//using Courses.Infrastructure.Netforum.Contexts;
//using FluentAssertions;
//using FluentValidation.Results;
//using TechTalk.SpecFlow;

//namespace Goodtocode.Application.Integration.LearnerCourses.Queries.GetAll;

//[Binding]
//[Scope(Tag = "getAllLearnerCoursesQueryV1")]
//public class GetLearnerCoursesQueryV1StepDefinitions : TestBase
//{
//    private bool _learnerCoursesExist;
//    private Guid _learnerKey;
//    private IDictionary<string, string[]> _responseErrors;
//    private ResponseType _responseType;
//    private List<ValidationFailure> _validationErrors;
//    private LearnerCoursesVm _response;


//    [Given(@"I have a Learner Key")]
//    public void GivenIHaveALearnerKey()
//    {
//        _learnerKey = Guid.Parse("ad790f32-f501-4838-8e4a-c1b057c44f30");
//    }

//    [Given(@"The learner exists")]
//    public void GivenTheLearnerExists()
//    {
//        _learnerCoursesExist = true;
//    }

//    [Given(@"I have a Learner Key and learner courses exist")]
//    public void GivenIHaveALearnerKeyAndLearnerCoursesExist()
//    {
//        _learnerKey = Guid.Parse("ad790f32-f501-4838-8e4a-c1b057c44f30");
//        _learnerCoursesExist = true;
//    }

//    [Given(@"I have a Learner Key and learner has no courses")]
//    public void GivenIHaveALearnerKeyAndLearnerHasNoCourses()
//    {
//        _learnerKey = Guid.Parse("ad790f32-f501-4838-8e4a-c1b057c00000");
//        _learnerCoursesExist = false;
//    }


//    [When(@"I get the Learner Courses")]
//    public async Task WhenIGetTheLearnerCourses()
//    {
//        var context = new CoursesContext(new DbContextOptionsBuilder<CoursesContext>()
//            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

//        var certReviewCoursesRepo = new Mock<ICertReviewCourseRepo>();
        
//        var request = new GetLearnerCoursesQuery
//        {
//            LearnerKey = _learnerKey
//        };

//        var validator = new GetLearnerCoursesQueryValidator();
//        var validationResult = validator.Validate(request);

//        if (validationResult.IsValid)
//        {
//            try
//            {
//                var handler = new GetLearnerCoursesQueryHandler(context, certReviewCoursesRepo.Object);
//                _response = await SendAsync(request);
//                _responseType = ResponseType.Successful;
//            }
//            catch (Exception e)
//            {
//                switch (e)
//                {
//                    case NotFoundException:
//                        _responseType = ResponseType.NotFound;
//                        break;
//                    case ValidationException validationException:
//                        _responseType = ResponseType.BadRequest;
//                        _responseErrors = validationException.Errors;
//                        break;
//                    default:
//                        _responseType = ResponseType.Error;
//                        break;
//                }
//            }
//        }
//        else
//        {
//            _responseType = ResponseType.BadRequest;
//            _validationErrors = validationResult.Errors;
//        }
//    }
//    [Then(@"Response contains an empty collection of learner courses")]
//    public void ThenResponseContainsAnEmptyCollectionOfLearnerCourses()
//    {
//        _response.LearnerCourses.Any().Should().BeFalse();
//    }

    

//    [Then(@"The response is successful")]
//    public void ThenTheResponseIsSuccessful()
//    {
//        _responseType.Should().Be(ResponseType.Successful);
//    }

//    [Then(@"The response contains a collection of LearnerCourses")]
//    public void ThenTheResponseContainsACollectionOfLearnerCourses()
//    {
//        _response.LearnerCourses.Any().Should().BeTrue();
//    }

//    [Then(@"Each LearnerCourse contains a ExternalCourseKey")]
//    public void ThenEachLearnerCourseContainsAExternalCourseKey()
//    {
//        foreach (var learnerCourse in _response.LearnerCourses)
//        {
//            learnerCourse.ExternalCourseKey.Should().NotBeNull();
//        }
//    }

//    [Then(@"Each LearnerCourse contains a ShortTitle")]
//    public void ThenEachLearnerCourseContainsAShortTitle()
//    {
//        foreach (var learnerCourse in _response.LearnerCourses)
//        {
//            learnerCourse.ShortTitle.Should().NotBeNullOrWhiteSpace();
//        }
//    }

//    [Then(@"Each LearnerCourse contains a PercentComplete")]
//    public void ThenEachLearnerCourseContainsAPercentComplete()
//    {
//        foreach (var learnerCourse in _response.LearnerCourses)
//        {
//            learnerCourse.PercentComplete.Should().BeGreaterOrEqualTo(-1);
//        }
//    }

//    [Then(@"Each LearnerCourse contains a AccessExpirationDate")]
//    public void ThenEachLearnerCourseContainsAAccessExpirationDate()
//    {
//        foreach (var learnerCourse in _response.LearnerCourses)
//        {
//            //Fact that can iterate mean date exists
//            //Can be DateTime.MinValue
//        }
//    }

//    [Then(@"Each LearnerCourse contains a CeHoursAvailable")]
//    public void ThenEachLearnerCourseContainsACeHoursAvailable()
//    {
//        foreach (var learnerCourse in _response.LearnerCourses)
//        {
//            learnerCourse.CeHoursAvailable.Should().BeGreaterThan(-1);
//        }
//    }

//    [Then(@"Each LearnerCourse contains a CeHoursCompleted")]
//    public void ThenEachLearnerCourseContainsACeHoursCompleted()
//    {
//        foreach (var learnerCourse in _response.LearnerCourses)
//        {
//            learnerCourse.CeHoursAvailable.Should().BeGreaterThan(-1);
//        }
//    }

//    [Given(@"I have a Learner Key and the Learner does not exist")]
//    public void GivenIHaveALearnerKeyAndTheLearnerDoesNotExist()
//    {
//        _learnerKey = Guid.NewGuid();
//        _learnerCoursesExist = false;

//    }

//    [Given(@"The learner does not exist")]
//    public void GivenTheLearnerDoesNotExist()
//    {
//        throw new PendingStepException();
//    }

//    [Then(@"The response is not found")]
//    public void ThenTheResponseIsNotFound()
//    {
//        throw new PendingStepException();
//    }

//    [Given(@"I have a Learner")]
//    public void GivenIHaveALearner()
//    {
//    }

//    [Given(@"I have an empty Learner Key")]
//    public void GivenIHaveAnEmptyLearnerKey()
//    {
//        _learnerKey = Guid.Empty;
//    }

//    [Then(@"The response is a bad request")]
//    public void ThenTheResponseIsABadRequest()
//    {
//        _responseType.Should().Be(ResponseType.BadRequest);
//    }

//    [Then(@"The response errors tells me the learner key is required")]
//    public void ThenTheResponseErrorsTellsMeTheLearnerKeyIsRequired()
//    {
//        _validationErrors.Any(x => x.PropertyName == "LearnerKey").Should().BeTrue();
//    }


//}