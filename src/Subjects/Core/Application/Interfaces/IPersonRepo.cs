//using Goodtocode.Subjects.Domain.Conferences.Models;
//using Goodtocode.Subjects.Domain.Persons.Entities;
//using Goodtocode.Subjects.Domain.Persons.Models;
//using CSharpFunctionalExtensions;
//using Goodtocode.Subjects.Domain.TicketedSessions.Entities;

//namespace Goodtocode.Subjects.Application.Common.Interfaces;

//public interface IPersonsRepo
//{
//    /// <summary>
//    ///     Person Repository
//    /// </summary>
//    /// <param name="recNo">Customers RecNo or 0 to bring back all ticketed sessions</param>
//    /// <param name="conferenceType">live or virtual</param>
//    /// <param name="cancellationToken"></param>
//    /// <returns></returns>
//    Task<Result<List<Person>>> GetPersonsAsync(int recNo, ConferenceType conferenceType,
//        CancellationToken cancellationToken);

//    Task<Result> UpdatePersonInfoAsync(UpdatedPersonInfo personInfo,
//        CancellationToken cancellationToken);
//}