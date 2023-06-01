using CSharpFunctionalExtensions;
using FluentValidation.Results;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Application.Common.Exceptions;
using Goodtocode.Subjects.Domain;
using System.Collections.Concurrent;
using static Goodtocode.Subjects.Integration.Common.ResponseTypes;

namespace Goodtocode.Subjects.Integration.Business.Queries;

[Binding]
[Scope(Tag = "getBusinessesByKey")]
public class GetBusinessesByKeyStepDefinitions : TestBase
{
    private IDictionary<string, string[]> _commandErrors = new ConcurrentDictionary<string, string[]>();
    private string[]? _expectedInvalidFields;
    private BusinessEntity _response = new();
    private CommandResponseType _responseType;
    private ValidationResult _validationErrors = new();
    private Guid _businessKey = Guid.Empty;
    private bool _businessExists;

    [Given(@"I have a def ""([^""]*)""")]
    public void GivenIHaveADef(string def)
    {
        _def = def;
    }

    [Given(@"I have a BusinessKey ""([^""]*)""")]
    public void GivenIHaveABusinessName(Guid businessKey)
    {
        _businessKey = businessKey;
    }

    [Given(@"the business exists ""([^""]*)""")]
    public void GivenTheBusinessExists(bool exists)
    {
        _businessExists = exists;
    }

    [When(@"I query for matching Businesses")]
    public async Task WhenIQueryForMatchingBusinesses()
    {
        var request = new GetBusinessQuery
        {
            BusinessKey = _businessKey
        };

        var requestValidator = new GetBusinessQueryValidator();

        _validationErrors = await requestValidator.ValidateAsync(request);

        if (_validationErrors.IsValid)
            try
            {
                var handler = new GetBusinessQueryHandler(BusinessRepo, Mapper);
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

    [Then(@"if the response is valid then the response contains a business")]
    public void ThenIfTheResponseIsValidThenTheResponseContainsABusiness()
    {
        if (_responseType != CommandResponseType.Successful) return;
        _response.BusinessKey.Should().NotBeEmpty();
    }

    [Then(@"the business has a matching BusinessKey of ""([^""]*)""")]
    public void ThenTheBusinessHasAMatchingBusinessKeyOf(Guid businessKey)
    {
        if (_responseType != CommandResponseType.Successful) return;
        _response.BusinessKey.Should().Be(businessKey);
    }

}