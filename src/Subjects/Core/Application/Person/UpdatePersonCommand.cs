//using Goodtocode.Subjects.Application.Common.Interfaces;
//using Goodtocode.Subjects.Domain.Conferences.Models;
//using Goodtocode.Subjects.Domain.Persons.Entities;
//using Goodtocode.Subjects.Domain.Persons.Models;
//using MediatR;

//namespace Goodtocode.Subjects.Application.Persons.Commands.Update;

//public class UpdatePersonCommand : IRequest
//{
//    public Guid PersonKey { get; set; }
//    public string FirstName { get; set; }
//    public string MiddleName { get; set; }
//    public string LastName { get; set; }
//    public DateTime BirthDate { get; set; }
//    public string GenderCode { get; set; }
//}

//public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
//{
//    private readonly IPersonsRepo _userPersonsRepo;

//    public UpdatePersonCommandHandler(IPersonsRepo PersonsRepo)
//    {
//        _userPersonsRepo = PersonsRepo;
//    }

//    public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
//    {
//        var updateResult =
//            await _userPersonsRepo.UpdatePersonInfoAsync(updateRequest, cancellationToken);

//        if (updateResult.IsFailure)
//            throw new Exception(updateResult.Error);
//    }
//}