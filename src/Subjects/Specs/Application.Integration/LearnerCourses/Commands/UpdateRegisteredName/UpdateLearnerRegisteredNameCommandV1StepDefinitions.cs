//using Courses.Core.Application.Common.Exceptions;
//using Courses.Core.Application.Common.Interfaces;
//using Courses.Core.Application.LearnerCourses.Commands.UpdateRegisteredName;
//using Courses.Core.Domain.LearnerRegistrations.Models;
//using Azure;
//using CSharpFunctionalExtensions;
//using FluentAssertions;
//using FluentValidation.Results;
//using TechTalk.SpecFlow;

//namespace Goodtocode.Application.Integration.LearnerCourses.Commands.UpdateRegisteredName;

//[Binding]
//[Scope(Tag = "updateRegisteredNameCommandV1")]
//public class UpdateLearnerRegisteredNameCommandV1StepDefinitions : TestBase
//{
//    private string _firstName;
//    private string _lastName;
//    private Guid _learnerKey;
//    private TestBase.ResponseType _responseType;
//    private IDictionary<string, string[]> _responseErrors = new Dictionary<string, string[]>();
//    private List<ValidationFailure> _validatorErrors = new List<ValidationFailure>();

//    [Given(@"I have a learnerKey And The learner exists")]
//    public void GivenIHaveALearnerKeyAndTheLearnerExists()
//    {
//        _learnerKey = Guid.Parse("ad790f32-f501-4838-8e4a-c1b057c44f30");
//    }

//    [Given(@"I have a learnerKey and the learner does not exist")]
//    public void GivenIHaveALearnerKeyAndTheLearnerDoesNotExist()
//    {
//        _learnerKey = Guid.Parse("ad790f32-f501-4838-8e4a-000000000000");
//    }

//    [Given(@"I have a learners firstName")]
//    public void GivenIHaveALearnersFirstName()
//    {
//        _firstName = "ErikNew";
//    }

//    [Given(@"I have a learners lastName")]
//    public void GivenIHaveALearnersLastName()
//    {
//        _lastName = "ChrisNew";
//    }

//    [When(@"I update the Learner Course Registered Name")]
//    public async Task WhenIUpdateTheLearnerCourseRegisteredName()
//    {
//        var request = new UpdateLearnerCourseRegistrationNameCommand
//        {
//            LearnerKey = _learnerKey,
//            FirstName = _firstName,
//            Lastname = _lastName
//        };

//        var requestValidator = new UpdateLearnerCourseRegistrationNameCommandValidator();
//        var validationResult = requestValidator.Validate(request);

//        if (validationResult.IsValid)
//        {
//            try
//            {
//                await SendAsync(request);
//                _responseType = TestBase.ResponseType.Successful;
//            }
//            catch (Exception e)
//            {
//                switch (e)
//                {
//                    case NotFoundException notFoundException:
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
//            _validatorErrors = validationResult.Errors;
//        }
//    }

//    [Then(@"The response is successful")]
//    public void ThenTheResponseIsSuccessful()
//    {
//        _responseType.Should().Be(ResponseType.Successful);
//    }

//    [Then(@"The response tells me the Learner Course does not found")]
//    public void ThenTheResponseTellsMeTheLearnerCourseDoesNotFound()
//    {
//        _responseType.Should().Be(ResponseType.NotFound);
//    }

//    [Given(@"I have an empty learnerKey")]
//    public void GivenIHaveAnEmptyLearnerKey()
//    {
//        _learnerKey = Guid.Empty;
//    }

//    [Given(@"I have an empty learners firstName")]
//    public void GivenIHaveAnEmptyLearnersFirstName()
//    {
//        _firstName = string.Empty;
//    }

//    [Given(@"I have an empty learners lastName")]
//    public void GivenIHaveAnEmptyLearnersLastName()
//    {
//        _lastName = string.Empty;
//    }

//    [Then(@"The response tells me I mad a bad request")]
//    public void ThenTheResponseTellsMeIMadABadRequest()
//    {
//        _responseType.Should().Be(ResponseType.BadRequest);
//    }

//    [Then(@"The response validation errors tell me the learners firstName is required")]
//    public void ThenTheResponseErrorsTellMeTheLearnersFirstNameIsRequired()
//    {
//        _validatorErrors.Any(x => x.PropertyName == "FirstName");
//    }

//    [Then(@"The response validation errors tell me the learners lastName is required")]
//    public void ThenTheResponseErrorsTellMeTheLearnersLastNameIsRequired()
//    {
//        _validatorErrors.Any(x => x.PropertyName == "LastName");
//    }

//    [Then(@"The response validation errors tell me the externalCourseId is required")]
//    public void ThenTheResponseErrorsTellMeTheExternalCourseIdIsRequired()
//    {
//        _validatorErrors.Any(x => x.PropertyName == "ExternalCourseid");
//    }

//    [Then(@"The response validation errors tell me the learnerKey is required")]
//    public void ThenTheResponseErrorsTellMeTheLearnerKeyIsRequired()
//    {
//        _validatorErrors.Any(x => x.PropertyName == "LearnerKey");
//    }

//}