using GoodToCode.Extensions.Mvc;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Authorization;
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
    [ApiVersion("1.0")]
    public class BusinessesController : ControllerMediator
    {
        private readonly SubjectsDbContext _dbContext;

        public BusinessesController(SubjectsDbContext context)
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
        [HttpPut("{key}")]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 202)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 400)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 401)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 406)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 500)]
        public async Task<ActionResult<CommandResponseWrapper<bool>>> PutBusiness(Guid key, [FromBody] BusinessSaveCommand command)
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

        // POST: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpPost()]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 202)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 400)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 401)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 406)]
        [ProducesResponseType(typeof(CommandResponseWrapper<bool>), 500)]
        public async Task<ActionResult<CommandResponseWrapper<bool>>> PostBusiness([FromBody] BusinessSaveCommand command)
        {
            var cmdResponse = await Mediator.Send(command);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, cmdResponse);

            return Accepted(cmdResponse);
        }

        // DELETE: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpDelete("{key}")]
        public async Task<ActionResult<Business>> DeleteBusiness(Guid key)
        {
            var business = await _dbContext.Business.FindAsync(key);
            if (business == null)
            {
                return NotFound();
            }

            _dbContext.Business.Remove(business);
            await _dbContext.SaveChangesAsync();

            return business;
        }
    }
}