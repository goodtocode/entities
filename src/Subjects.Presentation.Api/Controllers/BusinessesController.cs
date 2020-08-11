using GoodToCode.Extensions.Mvc;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Domain;
using GoodToCode.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application.Controller
{
    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "BusinessSpecification")]
    [Route("/v{version:apiVersion}/BusinessSave/{key}")]
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
        /// <param name="key"></param>
        /// <returns>CommandResult</returns>
        [Authorize]
        [HttpPost(Name = "BusinessSave")]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 202)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 400)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 401)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 406)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 500)]
        public async Task<ActionResult<CommandResponseWrapper<bool>>> BusinessSave([FromBody] BusinessSaveCommand command, Guid key)
        {
            var cmdResponse = await Mediator.Send(command);

            if (key != command.Item.BusinessKey)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, cmdResponse);

            return Accepted(cmdResponse);
        }
    }
}