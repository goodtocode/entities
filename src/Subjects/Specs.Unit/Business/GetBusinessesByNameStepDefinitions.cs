using CSharpFunctionalExtensions;
using FluentValidation.Results;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Application.Common.Exceptions;
using Goodtocode.Subjects.Domain;
using Moq;
using System.Collections.Concurrent;
using static Goodtocode.Subjects.Unit.Common.ResponseTypes;

namespace Goodtocode.Subjects.Unit.Business;

[Binding]
[Scope(Tag = "getBusinessesByName")]
public class GetBusinessesByNameStepDefinitions : TestBase
{
    private IDictionary<string, string[]> _commandErrors = new ConcurrentDictionary<string, string[]>();
    private string[]? _expectedInvalidFields;
    private List<BusinessEntity> _response = new();
    private CommandResponseType _responseType;
    private ValidationResult _validationErrors = new();
    private string _businessName = string.Empty;
    private bool _businessExists;

    [Given(@"I have a def ""([^""]*)""")]
    public void GivenIHaveADef(string p0)
    {
        _def = p0;
    }

    [Given(@"I have a BusinessName ""([^""]*)""")]
    public void GivenIHaveABusinessName(string businessInDb)
    {
        _businessName = businessInDb;
    }

    [Given(@"the business exists ""([^""]*)""")]
    public void GivenTheBusinessExists(bool exists)
    {
        _businessExists = exists;
    }

    [When(@"I query for matching Businesses")]
    public async Task WhenIQueryForMatchingBusinesses()
    {
        var userBusinessesRepoMock = new Mock<IBusinessRepo>();

        if (_businessExists)
        {
            userBusinessesRepoMock
                .Setup(x => x.GetBusinessesByNameAsync(_businessName, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Result.Success(new List<BusinessEntity>
                {
                    new()
                    {
                        BusinessKey = new Guid(),
                        BusinessName = "BusinessInDb"
                    }
                })));
        }

        var request = new GetBusinessesByNameQuery
        {
            BusinessName = _businessName
        };

        var requestValidator = new GetBusinessesByNameQueryValidator();

        _validationErrors = await requestValidator.ValidateAsync(request);

        if (_validationErrors.IsValid)
            try
            {
                var handler = new GetBusinessesByNameQueryHandler(userBusinessesRepoMock.Object);
                _response = await handler.Handle(request, CancellationToken.None);
                _responseType = CommandResponseType.Successful;
            }
            catch (Exception e)
            {
                if (e is ValidationException validationException)
                {
                    _commandErrors = validationException.Errors;
                    _responseType = CommandResponseType.BadRequest;
                }

                else if (e is NotFoundException notFoundException)
                {
                    _responseType = CommandResponseType.NotFound;
                }
                else
                {
                    _responseType = CommandResponseType.Error;
                }
            }
        else
            _responseType = CommandResponseType.BadRequest;
    }

    [Then(@"the response is ""([^""]*)""")]
    public void ThenTheResponseIs(string response)
    {
        switch (response)
        {
            case "Success":
                _responseType.Should().Be(CommandResponseType.Successful);
                break;
            case "BadRequest":
                _responseType.Should().Be(CommandResponseType.BadRequest);
                break;
            case "NotFound":
                _responseType.Should().Be(CommandResponseType.NotFound);
                break;
        }
    }

    [Then(@"if the response has validation issues I see the ""([^""]*)"" in the response")]
    public void ThenIfTheResponseHasValidationIssuesISeeTheInTheResponse(string responseErrors)
    {
        if (string.IsNullOrWhiteSpace(responseErrors)) return;

        _expectedInvalidFields = responseErrors.Split(",");

        foreach (var field in _expectedInvalidFields)
        {
            var hasCommandValidatorErrors = _validationErrors.Errors.Any(x => x.PropertyName == field.Trim());
            var hasCommandErrors = _commandErrors.Any(x => x.Key == field.Trim());
            var hasErrorMatch = hasCommandErrors || hasCommandValidatorErrors;

            hasErrorMatch.Should().BeTrue();
        }
    }

    [Then(@"if the response is valid then the response contains a collection of businesses")]
    public void ThenIfTheResponseIsValidThenTheResponseContainsACollectionOfBusinesses()
    {
        if (_responseType != CommandResponseType.Successful) return;
        _response.Any().Should().BeTrue();
    }

    [Then(@"each business has a matching BusinessName of ""([^""]*)""")]
    public void ThenEachBusinessHasAMatchingBusinessNameOf(string businessInDb)
    {
        if (_responseType != CommandResponseType.Successful) return;
        foreach (var business in _response) business.BusinessName.Should().Be(businessInDb);
    }
}