//using CSharpFunctionalExtensions;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using System.Data;

//namespace Goodtocode.Subjects.Persistence.Netfourm.TickedSessions;

//public class PersonsRepo : IPersonsRepo
//{
//    private readonly ISubjectsDbContext _context;

//    public PersonsRepo(ISubjectsDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<Result<List<Person>>> GetTickedSessionsAsync(int recNo, ConferenceType conferenceType,
//        CancellationToken cancellationToken)
//    {
//        object[] sqlParameters =
//        {
//            new SqlParameter
//            {
//                ParameterName = "@cst_recno",
//                SqlDbType = SqlDbType.BigInt,
//                Direction = ParameterDirection.Input,
//                Value = recNo
//            },
//            new SqlParameter
//            {
//                ParameterName = "@conference_type",
//                SqlDbType = SqlDbType.BigInt,
//                Direction = ParameterDirection.Input,
//                Value = recNo
//            },
//            new SqlParameter
//            {
//                ParameterName = "@response",
//                SqlDbType = SqlDbType.Bit,
//                Direction = ParameterDirection.Output
//            }
//        };

//        var q = @"EXEC @response = [service_events].[customer_ticketed_sessions_get] @cst_recno, @conference_type";


//        try
//        {
//            var PersonsResult = await _context.Person.FromSqlRaw(q, sqlParameters)
//                .ToListAsync(CancellationToken.None);


//            return Result.Success(PersonsResult);
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e);
//            throw;
//        }

//        return Result.Failure<List<Person>>("An error has occurred");
//    }

//    public async Task<Result> UpdatePersonInfoAsync(UpdatedPersonInfo PersonInfo,
//        CancellationToken cancellationToken)
//    {
//        object[] sqlParameters =
//        {
//            new SqlParameter
//            {
//                ParameterName = "@cst_recno",
//                SqlDbType = SqlDbType.VarChar,
//                Direction = ParameterDirection.Input,
//                Value = PersonInfo.RecNo
//            },

//            new SqlParameter
//            {
//                ParameterName = "@user_id",
//                SqlDbType = SqlDbType.BigInt,
//                Direction = ParameterDirection.Input,
//                Value = PersonInfo.UserId
//            },

//            new SqlParameter
//            {
//                ParameterName = "@conference_type",
//                SqlDbType = SqlDbType.VarChar,
//                Direction = ParameterDirection.Input,
//                Value = PersonInfo.ConferenceType
//            },

//            new SqlParameter
//            {
//                ParameterName = "@session_code",
//                SqlDbType = SqlDbType.VarChar,
//                Direction = ParameterDirection.Input,
//                Value = PersonInfo.SessionCode
//            },

//            new SqlParameter
//            {
//                ParameterName = "@transaction_type",
//                SqlDbType = SqlDbType.VarChar,
//                Direction = ParameterDirection.Input,
//                Value = PersonInfo.TransactionType
//            },

//            new SqlParameter
//            {
//                ParameterName = "@rgs_api_status_ext",
//                SqlDbType = SqlDbType.VarChar,
//                Direction = ParameterDirection.Input,
//                Value = PersonInfo.Status
//            },
//            new SqlParameter
//            {
//                ParameterName = "@rgs_api_result_ext",
//                SqlDbType = SqlDbType.VarChar,
//                Direction = ParameterDirection.Input,
//                Value = PersonInfo.StatusResult
//            },
//            new SqlParameter
//            {
//                ParameterName = "@return_value",
//                SqlDbType = SqlDbType.Bit,
//                Direction = ParameterDirection.Output
//            }
//        };


//        var sql = @"EXEC @return_value =[service_events].[customer_ticketed_session_update]
//		@cst_recno,
//		@user_id,
//		@conference_type,
//		@session_code,
//		@transaction_type,
//		@rgs_api_status_ext,
//		@rgs_api_result_ext 
//        SELECT	'Return Value' = @return_value";


//        var response = await _context.PersonsUpdateResponse.FromSqlRaw(sql, sqlParameters)
//            .ToListAsync(cancellationToken);

//        var isSuccessful = response[0].IsSuccessful;

//        return !isSuccessful ? Result.Failure("Error updating customer ticketed session") : Result.Success();
//    }
//}