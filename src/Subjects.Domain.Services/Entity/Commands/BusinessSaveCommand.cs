//using GoodToCode.Shared.Models;
//using GoodToCode.Subjects.Models;
//using MediatR;
//using Microsoft.EntityFrameworkCore.Internal;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//namespace GoodToCode.Subjects.Domain
//{
//    public class BusinessSaveResultCommand : IRequest<CommandResponseWrapper<bool>>
//    {
//        /// <summary>
//        /// Testrun Customer Id
//        /// </summary>
//        public int CustomerId { get; set; }

//        /// <summary>
//        /// Testrun Program Id
//        /// Has a max character length of 10
//        /// </summary>
//        public int ProgramId { get; set; }

//        /// <summary>
//        /// Testrun's Exam Id
//        /// </summary>
//        public int ExamId { get; set; }
        
//        /// <summary>
//        /// The total number of exam questions
//        /// </summary>
//        public int QuestionsCount { get; set; }

//        /// <summary>
//        /// The total number exam questions correct
//        /// </summary>
//        public int QuestionsCorrect { get; set; }

//        /// <summary>
//        /// The total number of exam attempts by the user 
//        /// </summary>
//        public int Attempts { get; set; }

//        /// <summary>
//        /// Exam status of either 'Pass' or 'Fail'
//        /// </summary>
//        public string Status { get; set; }

//        /// <summary>
//        /// The DateTime when the Exam was taken (Unix Epoch Format)
//        /// </summary>
//        public double ExamTakenDateTime { get; set; }

//        /// <summary>
//        /// The vendor that is making the call
//        /// </summary>
//        internal string Vendor { get; set; }

//        /// <summary>
//        /// The Exam Type
//        /// Example: Microcredential
//        /// </summary>
//        internal string ExamType { get; set; }

//        public BusinessSaveResultCommand() { }

//        public BusinessSaveResultCommand(int customerId, int programId, int examId, int questionsCount, int questionsCorrect, int attempts, string status, double examTakenDateTime, string vendorId, string examType)
//        {
//            CustomerId = customerId;
//            ProgramId = programId;
//            ExamId = examId;
//            QuestionsCount = questionsCount;
//            QuestionsCorrect = questionsCorrect;
//            Attempts = attempts;
//            Status = status;
//            ExamTakenDateTime = examTakenDateTime;
//            Vendor = vendorId;
//            ExamType = examType;
//        }

//        public void SetExamVendorAndType(string vendor, string examType)
//        {
//            Vendor = vendor;
//            ExamType = examType;
//        }

//        public class Handler : IRequestHandler<BusinessSaveResultCommand, CommandResponseWrapper<bool>>
//        {
//            private readonly BusinessSaveCommandValidator _validator;
//            private readonly List<KeyValuePair<string, string>> _errors;
//            private ISubjectsDbContext _context;
//            private IConfiguration _configuration;

//            public Handler(ISubjectsDbContext context, IConfiguration configuration)
//            {
//                _configuration = configuration;
//                _context = context;
//                _validator = new BusinessSaveCommandValidator();
//                _errors = new List<KeyValuePair<string, string>>();
//            }

//            public async Task<CommandResponseWrapper<bool>> Handle(BusinessSaveResultCommand request, CancellationToken cancellationToken)
//            {
//                var result = new CommandResponseWrapper<bool>() { Errors = getRequestParamErrors(request) };

//                if (!EnumerableExtensions.Any(result.Errors))
//                {
//                    //Core.Domain.ExamResults.V1.Entities.ExamResult exam;
//                    //{
//                    //    var examResultInfo = ExamResultInfo.Create(
//                    //        request.CustomerId,
//                    //        request.ProgramId,
//                    //        request.ExamId,
//                    //        request.QuestionsCount,
//                    //        request.QuestionsCorrect,
//                    //        request.Attempts,
//                    //        request.Status,
//                    //        request.ExamTakenDateTime);

//                    //    if (examResultInfo.IsSuccess)
//                    //    {
//                    //        exam = new Core.Domain.ExamResults.V1.Entities.ExamResult(examResultInfo.Value, Guid.NewGuid(), DateTime.UtcNow, request.Vendor, request.ExamType);
//                    //        _context.ExamResult.Add(exam);
//                    //    }

//                    //    try
//                    //    {
//                    //          await _context.SaveChangesAsync(cancellationToken);

//                    //        result.Result = true;
//                    //    }
//                    //    catch (Exception e)
//                    //    {
//                    //        Console.WriteLine(e);

//                    //        result.ErrorInfo = new ErrorInfo()
//                    //        {
//                    //            UserErrorMessage = "An internal error has occured",
//                    //            HasException = true
//                    //        };
//                    //    }
//                    }
//                }
//                return result;
//            }

//            private List<KeyValuePair<string, string>> getRequestParamErrors(BusinessSaveResultCommand request)
//            {
//                var issues = _validator.Validate(request).Errors;

//                if (request.QuestionsCorrect > request.QuestionsCount)
//                    _errors.Add(new KeyValuePair<string, string>("QuestionsCorrect", "Questions Correct Cannot be greater than Questions Count"));


//                if (request.Status != "Pass" && request.Status != "Fail")
//                    _errors.Add(new KeyValuePair<string, string>("Status", "Invalid Status"));

//                if (request.Vendor != "testrun")
//                    _errors.Add(new KeyValuePair<string, string>("Vendor", "Invalid Vendor"));

//                if (request.ExamType != "microcredential")
//                    _errors.Add(new KeyValuePair<string, string>("ExamType", "Invalid ExamType"));

//                foreach (var issue in issues)
//                    _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
//                return _errors;
//            }

//        }
//    }
//}
