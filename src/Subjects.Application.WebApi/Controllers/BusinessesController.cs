using System.Net;
using System.Threading.Tasks;
using Aacn.Exams.Presentation.Api.External.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace GoodToCode.Subjects.Application.Controller
{
    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "ExamsAPISpecification")]
    [Route("api/v{version:apiVersion}/{vendor}/ExamResults/{exam}")]
    [ApiVersion("1.0")]
    public class BusinessesController : ControllerMediator
    {
        /// <summary>
        /// Post Exam Result
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///           Parameters:
        /// 
        ///           Vendor: vendor
        ///           Exam:   exam
        ///           Version: 1.0
        ///
        ///           Request Body:
        /// 
        ///           {
        ///                "CustomerId": 123,
        ///                "ProgramId": 456,
        ///                "ExamId": 789,
        ///                "QuestionsCount": 10,
        ///                "QuestionsCorrect": 9,
        ///                "Attempts": 1,
        ///                "Status": "Pass",
        ///                "ExamTakenDateTime": 1594238468
        ///            }
        ///
        /// 
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>CommandResult</returns>
        [Authorize]
        [HttpPost(Name = "PostExamResult")]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 202)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 400)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 401)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 406)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 500)]
        public async Task<ActionResult<CommandResponseWrapper<bool>>> ReceiveExamResult([FromBody] PostExamResultCommand command, string vendor, string exam)
        {
            command.SetExamVendorAndType(vendor, exam);

            var cmdResponse = await Mediator.Send(command);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, cmdResponse);

            return Accepted(cmdResponse);
        }
    }
}