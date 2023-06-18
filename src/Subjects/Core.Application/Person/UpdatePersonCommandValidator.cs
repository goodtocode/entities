//using FluentValidation;

//namespace Goodtocode.Subjects.Application.Persons.Commands.Update;

//public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
//{
//    public UpdatePersonCommandValidator()
//    {
//        RuleFor(x => x.SessionCode).NotEmpty();
//        RuleFor(x => x.RecNo);
//        RuleFor(x => x.ConferenceUserId).NotEmpty();
//        RuleFor(x => x.TransactionType).Must(BeTransactionType).NotEmpty();
//        RuleFor(x => x.Status).Must(BeStatus).NotEmpty();
//        RuleFor(x => x.ConferenceType).Must(BeConfType).NotEmpty();

//        When(x => !string.IsNullOrWhiteSpace(x.AnyError),
//            () =>
//            {
//                When(y => y.Status.ToLower() == "success",
//                    () =>
//                    {
//                        RuleFor(x => x.Status.ToLower())
//                            .Equal("failure").WithMessage("When AnyError has value status should be 'failure'")
//                            .WithName("Status");
//                    });
//            });
//    }

//    public bool BeTransactionType(string type)
//    {
//        return (type.ToLower() == "add") | (type.ToLower() == "remove");
//    }

//    public bool BeConfType(string type)
//    {
//        return (type.ToLower() == "live") | (type.ToLower() == "virtual");
//    }

//    public bool BeStatus(string status)
//    {
//        return (status.ToLower() == "success") | (status.ToLower() == "failed");
//    }
//}