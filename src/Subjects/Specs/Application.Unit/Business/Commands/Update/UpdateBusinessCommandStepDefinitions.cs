using FluentValidation.Results;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Application.Business.Commands;
using Goodtocode.Subjects.Application.Common.Exceptions;
using Moq;
using System.Collections.Concurrent;
using static Goodtocode.Subjects.Unit.Common.ResponseTypes;

namespace Goodtocode.Subjects.Unit.Business.Commands.Update;

[Binding]
[Scope(Tag = "updateBusinessCommand")]
public class UpdateBusinessCommandStepDefinitions : TestBase
{
    private IDictionary<string, string[]> _commandErrors = new ConcurrentDictionary<string, string[]>();
    private string[]? _expectedInvalidFields;
    private Guid _businessKey;
    private string _businessName = string.Empty;
    private string _taxNumber = string.Empty;
    private object _responseType = string.Empty;
    private ValidationResult _validationErrors = new();

    [Given(@"I have a def ""([^""]*)""")]
    public void GivenIHaveADef(string def)
    {
        _def = def;
    }


    [Given(@"I have a BusinessKey ""([^""]*)""")]
    public void GivenIHaveABusinessKey(string businessKey)
    {
        Guid.TryParse(businessKey, out _businessKey);
    }

    [Given(@"I have a BusinessName ""([^""]*)""")]
    public void GivenIHaveABusinessName(string businessName)
    {
        _businessName = businessName;
    }

    [Given(@"I have a TaxNumber ""([^""]*)""")]
    public void GivenIHaveATaxNumber(string TaxNumber)
    {
        _taxNumber = TaxNumber;
    }

    [When(@"I update the business")]
    public async Task WhenIUpdateTheBusiness()
    {
        var userBusinessRepoMock = new Mock<IBusinessRepo>();

        var request = new UpdateBusinessCommand
        {
            BusinessKey = _businessKey,
            BusinessName = _businessName,
            TaxNumber = _taxNumber
        };

        var requestValidator = new UpdateBusinessCommandValidator();

        _validationErrors = await requestValidator.ValidateAsync(request);

        if (_validationErrors.IsValid)
            try
            {
                var handler = new UpdateBusinessCommandHandler(userBusinessRepoMock.Object);
                await handler.Handle(request, CancellationToken.None);
                _responseType = CommandResponseType.Successful;
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case ValidationException validationException:
                        _commandErrors = validationException.Errors;
                        _responseType = CommandResponseType.BadRequest;
                        break;
                    case NotFoundException notFoundException:
                        _responseType = CommandResponseType.NotFound;
                        break;
                    default:
                        _responseType = CommandResponseType.Error;
                        break;
                }
            }
        else
            _responseType = CommandResponseType.BadRequest;
    }

    [Then(@"The response is ""([^""]*)""")]
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

    [Then(@"If the response has validation issues I see the ""([^""]*)"" in the response")]
    public void ThenIfTheResponseHasValidationIssuesISeeTheInTheResponse(string expectedInvalidFields)
    {
        if (string.IsNullOrWhiteSpace(expectedInvalidFields)) return;

        _expectedInvalidFields = expectedInvalidFields.Split(",");

        foreach (var field in _expectedInvalidFields)
        {
            var hasCommandValidatorErrors = _validationErrors.Errors.Any(x => x.PropertyName == field.Trim());
            var hasCommandErrors = _commandErrors.Any(x => x.Key == field.Trim());
            var hasErrorMatch = hasCommandErrors || hasCommandValidatorErrors;

            hasErrorMatch.Should().BeTrue();
        }
    }
}