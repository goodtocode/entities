//using GoodToCode.Shared.Models;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace GoodToCode.Shared.Domain
//{
//    public class BusinessGetQuery : IRequest<QueryResponseWrapper<ExamResultVm>>
//    {
//        public BusinessGetQuery() { }

//        public BusinessGetQuery(int examId, int programId, int customerId)
//        {
//            ExamId = examId;
//            ProgramId = programId;
//            CustomerId = customerId;
//        }
        
//        public int CustomerId { get; set; }

//        public int ProgramId { get; set; }

//        public int ExamId { get; set; }

//        public class Handler : IRequestHandler<BusinessGetQuery, QueryResponseWrapper<ExamResultVm>>
//        {
     
//            private readonly IMapper _mapper;
//            private readonly GetLatestExamResultQueryValidator _validator;
//            private readonly List<KeyValuePair<string, string>> _errors;
//            private ITestrunRepo _testRunExamRepo;
//            private ILogger<BusinessGetQuery.Handler> _logger;

//            public Handler(ITestrunRepo testRunExamRepo, IMapper mapper)
//            {
            
//                _testRunExamRepo = testRunExamRepo;
//                _mapper = mapper;
//                _validator = new GetLatestExamResultQueryValidator();
//                _errors = new List<KeyValuePair<string, string>>();
//            }

//            public async Task<QueryResponseWrapper<ExamResultVm>> Handle(BusinessGetQuery request, CancellationToken cancellationToken)
//            {
//                var response = new QueryResponseWrapper<ExamResultVm>(){ Errors = getRequestParamErrors(request) };
               
//                if (!response.Errors.Any())
//                {
//                    try
//                    {
//                        var examResult = _testRunExamRepo.GetLatest(request.CustomerId, request.ProgramId, request.ExamId);
//                        response.Result = _mapper.Map<ExamResultVm>(examResult);

//                    }
//                    catch (Exception e)
//                    {
//                        _logger.LogCritical(e.ToString());
//                        response.ErrorInfo.UserErrorMessage = "Some Error Has Occured";
//                        response.ErrorInfo.HasException = true;
//                    }
//                }

//                return response;
//            }

//            private List<KeyValuePair<string, string>> getRequestParamErrors(BusinessGetQuery request)
//            {
//                var issues = _validator.Validate(request).Errors;

//                foreach (var issue in issues)
//                    _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));

//                return _errors;
//            }
//        }
//    }
//}
