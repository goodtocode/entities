using GoodToCode.Extensions.Mvc;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Domain;
using GoodToCode.Shared.Extensions;
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

namespace GoodToCode.Subjects.Application.Controller
{
    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "BusinessSpecification")]
    [Route("/v{version:apiVersion}/BusinessSave/{key}")]
    [ApiVersion("1.0")]
    public class BusinessesController : ControllerMediator
    {
        private readonly SubjectsDbContext _context;

        public BusinessesController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusiness()
        {
            return await _context.Business.ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Business>> GetBusiness(Guid key)
        {
            var business = await _context.Business.FindAsync(key);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }

        [Authorize]
        [HttpPost("{key}"), HttpPut("{key}")]
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

        // DELETE: api/Businesses/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Business>> DeleteBusiness(Guid key)
        {
            var business = await _context.Business.FindAsync(key);
            if (business == null)
            {
                return NotFound();
            }

            _context.Business.Remove(business);
            await _context.SaveChangesAsync();

            return business;
        }

        private bool BusinessExists(Guid key)
        {
            return _context.Business.Any(e => e.BusinessKey == key);
        }
    }
}