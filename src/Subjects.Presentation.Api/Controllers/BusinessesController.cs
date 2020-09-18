using GoodToCode.Extensions.Mvc;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "BusinessSpecification")]
    [Route("/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class BusinessesController : ControllerMediator
    {
        private readonly SubjectsDbContext _dbContext;

        public BusinessesController(SubjectsDbContext context, IMediator mediator) : base(mediator)
        {
            _dbContext = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusiness()
        {
            return await _dbContext.Business.ToListAsync();
        }

        // GET: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpGet("{key}")]
        public async Task<ActionResult<Business>> GetBusiness(Guid key)
        {
            var business = await _dbContext.Business.FindAsync(key);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }

        // PUT: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpPut()]
        [ProducesResponseType(typeof(CommandResponse<Business>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 202)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 400)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 401)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 406)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 500)]
        public async Task<ActionResult<Business>> PutBusiness([FromBody] Business item)
        {
            var command = new BusinessCreateCommand(item);
            var cmdResponse = await Mediator.Send(command);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, cmdResponse);

            return Accepted(cmdResponse.Result);
        }

        // POST: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpPost("{key}")]
        [ProducesResponseType(typeof(CommandResponse<Business>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 202)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 400)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 401)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 406)]
        [ProducesResponseType(typeof(CommandResponse<Business>), 500)]
        public async Task<ActionResult<Business>> PostBusiness(Guid key, [FromBody] BusinessUpdateCommand command)
        {
            var cmdResponse = await Mediator.Send(command);

            if (key != command.Item.BusinessKey)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, cmdResponse);

            return Accepted(cmdResponse.Result);
        }

        // DELETE: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpDelete("{key}")]
        public async Task<ActionResult<Business>> DeleteBusiness(Guid key)
        {
            var command = new BusinessDeleteCommand();
            var cmdResponse = await Mediator.Send(command);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, cmdResponse);

            return Accepted(cmdResponse.Result);
        }
    }
}