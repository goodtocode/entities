//using Courses.Core.Application.Common.Exceptions;
//using Courses.Core.Application.LearnerCourses.Queries.Get;
//using FluentAssertions;
//using FluentValidation.Results;
//using TechTalk.SpecFlow;

//namespace Goodtocode.Application.Integration.LearnerCourses.Queries.Get;

//[Binding]
//[Scope(Tag = "getUserCourseQueryV1")]
//public class GetLearnerCourseDetailQueryV1StepDefinitions : TestBase
//{
//    private bool _courseExists;
//    private Guid _courseKey;
//    private string _externalCourseid;
//    private IDictionary<string, string[]> _handlerErrors;
//    private Guid _learnerKey;
//    private ResponseType _responseType;
//    private List<ValidationFailure> _validationErrors;
//    private LearnerCourseVm _response;

//    [Given(@"I have a learnerKey and the learner exists")]
//    public void GivenIHaveALearnerKey()
//    {
//        _learnerKey = Guid.Parse("94781094-8100-4A6F-A192-F2E7650D99BC");
//    }

//    [Given(@"I have an externalCourseId and the learner course exists")]
//    public void GivenIHaveAnExternalCourseId()
//    {
//        _externalCourseid = "COVID19PUL";
//    }

//    [Given(@"I have a courseKey")]
//    public void GivenIHaveACourseKey()
//    {
//        _courseKey = Guid.Parse("D01F87DD-9356-4E1D-A8BF-91AA12C626BC");
//    }

//    [Given(@"The course exists")]
//    public void GivenTheCourseExists()
//    {
//        _courseExists = true;
//    }

//    [When(@"I get the Learner Course detail")]
//    public async Task WhenIGetTheLearnerCourseDetail()
//    {
//        var request = new GetLearnerCourseQuery
//        {
//            ExternalCourseId = _externalCourseid,
//            LearnerKey = _learnerKey
//        };

//        var validator = new GetLearnerCourseQueryValidator();
//        var validationResult = validator.Validate(request);

//        if (validationResult.IsValid)
//        {
//            try
//            {
//                _response = await SendAsync(request);
//            }
//            catch (Exception e)
//            {
//                switch (e)
//                {
//                    case ValidationException validationException:
//                        _responseType = ResponseType.BadRequest;
//                        _handlerErrors = validationException.Errors;
//                        break;
//                    case NotFoundException:
//                        _responseType = ResponseType.NotFound;
//                        break;
//                    default:
//                        _responseType = ResponseType.Error;
//                        break;
//                }
//            }
//        }
//        else
//        {
//            _validationErrors = validationResult.Errors;
//            _responseType = ResponseType.BadRequest;
//        }
//    }

//    [Then(@"Then the response is successful")]
//    public void ThenThenTheResponseIsSuccessful()
//    {
//        _responseType.Should().Be(ResponseType.Successful);
//    }

//    [Then(@"The response contains a LearnerCourseKey")]
//    public void ThenTheResponseContainsALearnerCourseKey()
//    {
//        _response.LearnerCourseKey.Should().Be(Guid.Parse("11c1c7be-4cd2-44dc-944b-77a94bb7008d"));
//    }

//    [Then(@"The response contains a CourseProductKey")]
//    public void ThenTheResponseContainsACourseProductKey()
//    {
//        _response.CourseProductKey.Should().Be(Guid.Parse("940a2650-3b2f-463c-b408-eefbcab16a7f"));
//    }

//    [Then(@"The response contains a ExternalCourseKey")]
//    public void ThenTheResponseContainsAExternalCourseKey()
//    {
//        _response.ExternalCourseKey.Should().Be("COVID19PUL");
//    }

//    [Then(@"The response contains a Title")]
//    public void ThenTheResponseContainsATitle()
//    {
//        _response.Title.Should().Be("COVID-19 Pulmonary, ARDS, and Ventilator Resources");
//    }

//    [Then(@"The response contains a Category")]
//    public void ThenTheResponseContainsACategory()
//    {
//        _response.Category.Should().BeEmpty();
//    }

//    [Then(@"The response contains a EstimatedTimeToCompleteMinutes")]
//    public void ThenTheResponseContainsAEstimatedTimeToCompleteMinutes()
//    {
//        _response.EstimatedTimeToCompleteMinutes.Should().Be(285);
//    }

//    [Then(@"The response contains a AccessExpirationDate")]
//    public void ThenTheResponseContainsAAccessExpirationDate()
//    {
//        _response.AccessExpirationDate.Should().Be(DateTime.Parse("3/25/2023 12:00:00 AM"));
//    }

//    [Then(@"The response contains a UserCes")]
//    public void ThenTheResponseContainsAUserCes()
//    {
//        _response.UserCes.Count.Should().Be(4);

//        var ce1 = _response.UserCes.First(x => x.Title == "Assessing and Managing Respiratory Failure and ARDS");
//        ce1.CeCompete.Should().BeFalse();
//        ce1.CEsAvailable.Should().Be(0.73m);
//        ce1.CerpAAvailable.Should().Be(0.73m);
//        ce1.CerpBComplete.Should().Be(0);
//        ce1.CerpBAvailable.Should().Be(0);
//        ce1.CerpCComplete.Should().Be(0);
//        ce1.CerpCAvailable.Should().Be(0);
//        ce1.PharmaComplete.Should().Be(0);
//        ce1.PharmaAvailable.Should().Be(0);
//        ce1.GetCEUrl.Should().Be("/education/elearningeval?id=COVID19P1A4.2");
//        ce1.AssociatedModuleComplete.Should().BeFalse();
//        ce1.CeCompete.Should().BeFalse();
//        ce1.CeExpirationDate.Should().Be(DateTime.Parse("3/25/2023 12:00:00 AM"));

//        var ce2 = _response.UserCes.First(x => x.Title == "Spontaneous Awakening and Breathing Trials, Neuromuscular Blockade, Ventilator Weaning, Extubation Priorities, and Preventing Complications From Mechanical Ventilation");
//        ce2.CeCompete.Should().BeFalse();
//        ce2.CEsAvailable.Should().Be(1.46m);
//        ce2.CerpAAvailable.Should().Be(1.46m);
//        ce2.CerpBComplete.Should().Be(0);
//        ce2.CerpBAvailable.Should().Be(0);
//        ce2.CerpCComplete.Should().Be(0);
//        ce2.CerpCAvailable.Should().Be(0);
//        ce2.PharmaComplete.Should().Be(0);
//        ce2.PharmaAvailable.Should().Be(0);
//        ce2.GetCEUrl.Should().Be("/education/elearningeval?id=COVID19P2A2.4");
//        ce2.AssociatedModuleComplete.Should().BeFalse();
//        ce2.CeCompete.Should().BeFalse();
//        ce2.CeExpirationDate.Should().Be(DateTime.Parse("3/25/2023 12:00:00 AM"));



//        var ce3 = _response.UserCes.First(x => x.Title == " Invasive Mechanical Ventilation: Priorities for Endotracheal Intubation, Tracheostomy Care, Ventilator Settings and Troubleshooting");

//        ce3.CeCompete.Should().BeFalse();
//        ce3.CEsAvailable.Should().Be(1.30m);
//        ce3.CerpAAvailable.Should().Be(1.30m);
//        ce3.CerpBComplete.Should().Be(0);
//        ce3.CerpBAvailable.Should().Be(0);
//        ce3.CerpCComplete.Should().Be(0);
//        ce3.CerpCAvailable.Should().Be(0);
//        ce3.PharmaComplete.Should().Be(0);
//        ce3.PharmaAvailable.Should().Be(0);
//        ce3.GetCEUrl.Should().Be("/education/elearningeval?id=COVID19P2A1.3");
//        ce3.AssociatedModuleComplete.Should().BeFalse();
//        ce3.CeCompete.Should().BeFalse();
//        ce3.CeExpirationDate.Should().Be(DateTime.Parse("3/25/2023 12:00:00 AM"));



//        var ce4 = _response.UserCes.First(x => x.Title == "ABG Analysis, Oxygen Delivery, Airway Management, and Non-invasive Positive Pressure Ventilation");

//        ce4.CeCompete.Should().BeFalse();
//        ce4.CEsAvailable.Should().Be(1.01m);
//        ce4.CerpAAvailable.Should().Be(1.01m);
//        ce4.CerpBComplete.Should().Be(0);
//        ce4.CerpBAvailable.Should().Be(0);
//        ce4.CerpCComplete.Should().Be(0);
//        ce4.CerpCAvailable.Should().Be(0);
//        ce4.PharmaComplete.Should().Be(0);
//        ce4.PharmaAvailable.Should().Be(0);
//        ce4.GetCEUrl.Should().Be("/education/elearningeval?id=COVID19P1A2.1");
//        ce4.AssociatedModuleComplete.Should().BeFalse();
//        ce4.CeExpirationDate.Should().Be(DateTime.Parse("3/25/2023 12:00:00 AM"));


//    }

//    [Then(@"The response contains a PercentComplete")]
//    public void ThenTheResponseContainsAPercentComplete()
//    {
//        _response.PercentComplete.Should().Be(0);
//    }

//    [Then(@"The response contains a AccessStatus")]
//    public void ThenTheResponseContainsAAccessStatus()
//    {
//       //Never Populated...
//       // _response.AccessStatus.Should().Be(0);
//    }

//    [Then(@"The response contains a ProgressStatus")]
//    public void ThenTheResponseContainsAProgressStatus()
//    {
//        _response.ProgressStatus.Should().Be("Active");
//    }

//    [Then(@"The response contains a Documents")]
//    public void ThenTheResponseContainsADocuments()
//    {
//        _response.Documents.Should().NotBeNull();
//    }

//    [Then(@"The response contains a CEStatementTitle")]
//    public void ThenTheResponseContainsACEStatementTitle()
//    {
//        _response.CEStatementText.Should().BeEmpty();
//    }

//    [Then(@"The response contains a CEStatementText")]
//    public void ThenTheResponseContainsACEStatementText()
//    {
//        _response.CEStatementTitle.Should().BeEmpty();
//    }

//    [Then(@"the response contains a collection of UserCes")]
//    public void ThenTheResponseContainsACollectionOfUserCes()
//    {
//        _response.UserCes.Any().Should().BeTrue();
//    }

//    [Then(@"each UserCe has a Title")]
//    public void ThenEachUserCeHasATitle()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.Title.Should().NotBeNullOrEmpty();
//        }
//    }

//    [Then(@"each UserCe has a CEsISComplete")]
//    public void ThenEachUserCeHasACEsISComplete()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            // Can be true or false
//        }
//    }

//    [Then(@"each UserCe has a CEsAvailable")]
//    public void ThenEachUserCeHasACEsAvailable()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CEsAvailable.Should().BeGreaterThan(0);
//        }
//    }

//    [Then(@"each UserCe has a CerpAComplete")]
//    public void ThenEachUserCeHasACerpAComplete()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CerpAComplete.Should().BeGreaterThan(-1);
//        }
//    }


//    //[Then(@"each UserCe has a CerpIsAvailable")]
//    //public void ThenEachUserCeHasACerpIsAvailable()
//    //{
//    //    throw new PendingStepException();
//    //}

//    [Then(@"each UserCe has a CerpBComplete")]
//    public void ThenEachUserCeHasACerpBComplete()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CerpBComplete.Should().Be(0);
//        }
//    }

//    [Then(@"each UserCe has a CerpBIsAvailable")]
//    public void ThenEachUserCeHasACerpBIsAvailable()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CerpBAvailable.Should().Be(0);
//        }
//    }

//    [Then(@"each UserCe has a CerpCComplete")]
//    public void ThenEachUserCeHasACerpCComplete()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CerpCComplete.Should().Be(0);
//        }
//    }

//    [Then(@"each UserCe has a CerpIsCAvailable")]
//    public void ThenEachUserCeHasACerpIsCAvailable()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CerpCAvailable.Should().Be(0);
//        }
//    }

//    [Then(@"each UserCe has a PharmaComplete")]
//    public void ThenEachUserCeHasAPharmaComplete()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.PharmaComplete.Should().Be(0);
//        }
//    }

//    [Then(@"each UserCe has a PharmaAvailable")]
//    public void ThenEachUserCeHasAPharmaAvailable()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.PharmaAvailable.Should().Be(0);
//        }
//    }

//    [Then(@"each UserCe has a GetCEUrl")]
//    public void ThenEachUserCeHasAGetCEUrl()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.GetCEUrl.Should().NotBeEmpty();
//        }
//    }

//    [Then(@"each UserCe has a CerpIsAvailable")]
//    public void ThenEachUserCeHasACerpIsAvailable()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CerpCAvailable.Should().Be(0);
//        }
//    }

//    [Then(@"each UserCe has a AssociatedScoComplete")]
//    public void ThenEachUserCeHasAAssociatedScoComplete()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CerpAComplete.Should().BeGreaterThan(-1);
//        }
//    }

//    [Then(@"each UserCe has a CeIsCompete")]
//    public void ThenEachUserCeHasACeIsCompete()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            //Can be true or false
//        }
//    }

//    [Then(@"each UserCe has a CeExpirationDate")]
//    public void ThenEachUserCeHasACeExpirationDate()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.CeExpirationDate.Should().Be(DateTime.Parse("3/25/2023 12:00:00 AM"));
//        }
//    }

//    [Then(@"The response contains a UserCourseUrl")]
//    public void ThenTheResponseContainsAUserCourseUrl()
//    {
//        foreach (var userCe in _response.UserCes)
//        {
//            userCe.GetCEUrl.Should().NotBeNullOrWhiteSpace();
//        }
//    }

//    [Then(@"the UserCourseUrl has a collection of documents Documents")]
//    public void ThenTheUserCourseUrlHasACollectionOfDocumentsDocuments()
//    {
//        _response.Documents.Should().NotBeNull();
//    }

//    [Then(@"each document has a Name")]
//    public void ThenEachDocumentHasAName()
//    {
//        foreach (var doc in _response.Documents)
//        {
//            doc.Name.Should().NotBeNullOrWhiteSpace();
//        }
//    }

//    [Then(@"each document has a Description")]
//    public void ThenEachDocumentHasADescription()
//    {
//        foreach (var doc in _response.Documents)
//        {
//            doc.Description.Should().NotBeNullOrWhiteSpace();
//        }
//    }

//    [Then(@"each document has a DownloadUrl")]
//    public void ThenEachDocumentHasADownloadUrl()
//    {
//        foreach (var doc in _response.Documents)
//        {
//            doc.DownloadUrl.Should().NotBeNullOrWhiteSpace();
//        }
//    }

//    [Then(@"each document has a Type")]
//    public void ThenEachDocumentHasAType()
//    {
//        foreach (var doc in _response.Documents)
//        {
//            doc.Type.Should().NotBeNullOrWhiteSpace();
//        }
//    }

//    [Given(@"I have an externaCourseId and the course does NOT exist")]
//    public void GivenIHaveAnExternaCourseIdAndTheCourseDoesNOTExist()
//    {
//        _externalCourseid = "DOES_NOT_EXIST";
//    }


//    [Then(@"Then the response tells me the User Course is not found")]
//    public void ThenThenTheResponseTellsMeTheUserCourseIsNotFound()
//    {
//        _responseType.Should().Be(ResponseType.NotFound);
//    }

//    [Given(@"I have an empty learnerKey")]
//    public void GivenIHaveAnEmptyLearnerKey()
//    {
//        _learnerKey = Guid.Empty;
//    }

//    [Given(@"I have an empty externaCourseId")]
//    public void GivenIHaveAnEmptyExternaCourseId()
//    {
//        _externalCourseid = string.Empty;
//    }

//    [Given(@"I have a empty courseId")]
//    public void GivenIHaveAEmptyCourseId()
//    {
//        _externalCourseid = string.Empty;
//    }

//    [Then(@"Then the response tells me I made a bad request")]
//    public void ThenThenTheResponseTellsMeIMadeABadRequest()
//    {
//        _responseType.Should().Be(ResponseType.BadRequest);
//    }

//    [Then(@"The response errors tell me the customerKey is required")]
//    public void ThenTheResponseErrorsTellMeTheCustomerKeyIsRequired()
//    {

//        _validationErrors.Any(x => x.PropertyName == "LearnerKey").Should().BeTrue();
//    }

//    [Then(@"The response errors tell me the externaCourseId is required")]
//    public void ThenTheResponseErrorsTellMeTheExternaCourseIdIsRequired()
//    {
//        _validationErrors.Any(x => x.PropertyName == "ExternalCourseId").Should().BeTrue();
//    }

//    [Then(@"The response errors tell me the courseId is required")]
//    public void ThenTheResponseErrorsTellMeTheCourseIdIsRequired()
//    {
//        _validationErrors.Any(x => x.PropertyName == "ExternalCourseId").Should().BeTrue();
//        _validationErrors.Any(x => x.PropertyName == "LearnerKey").Should().BeTrue();
//    }
//}