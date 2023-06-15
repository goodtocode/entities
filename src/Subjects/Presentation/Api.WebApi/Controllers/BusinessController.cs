using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Domain;
using Goodtocode.Subjects.WebApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace Goodtocode.Subjects.WebApi.Controllers;

/// <summary>
///     Businesses Controller V1.0
/// </summary>
[ApiController]
[ApiConventionType(typeof(DefaultApiConventions))]
[Route("[controller]")]
[ApiVersion("1.0")]
public class BusinessController : BaseController
{
    /// <summary> Get Business by Key</summary>
    /// <remarks>
    ///     Sample request:
    ///     "businessKey": "d3d42e6e-87c5-49d6-aec0-7995711d6612"
    ///     "api-version":  1
    /// </remarks>
    /// <returns>BusinessEntity</returns>
    [HttpGet(Name = "GetBusinessQuery")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<BusinessEntity> Get(Guid key)
    {
        return await Mediator.Send(new GetBusinessQuery
        {
            BusinessKey = key
        });
    }

    ///// <summary> Get Businesses by Name</summary>
    ///// <remarks>
    /////     Sample request:
    /////     "businessName": "My Business"
    /////     "api-version":  1
    ///// </remarks>
    ///// <returns>Collection of BusinessEntity</returns>
    //[HttpGet(Name = "GetBusinessesByNameQuery")]
    //[Route("api/businesses/{name}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<List<BusinessEntity>> Get([FromQuery] string name)
    //{
    //    return await Mediator.Send(new GetBusinessesByNameQuery
    //    {
    //        BusinessName = name
    //    });
    //}

    /// <summary>
    ///     Add Business
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     "api-version":  1
    ///     HttpPost Body
    ///     {
    ///     "BusinessName": "My Business",
    ///     "TaxNumber": "12-445666"
    ///     }
    /// </remarks>
    /// <returns>Created Item URI and Object</returns>
    [HttpPut(Name = "AddBusinessCommand")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put([FromBody] AddBusinessCommand command)
    {
        var createdEntity = await Mediator.Send(command);

        return Created(new Uri($"{Request.Path}/{createdEntity.Key}", UriKind.Relative), createdEntity);
    }

    /// <summary>
    ///     Update Business
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     "BusinessKey": d3d42e6e-87c5-49d6-aec0-7995711d6612,
    ///     "api-version":  1
    ///     HttpPost Body
    ///     {    
    ///     "BusinessName": "My Business",
    ///     "TaxNumber": "12-445666"
    ///     }
    /// </remarks>
    /// <returns>bool</returns>
    [HttpPost(Name = "UpdateBusinessCommand")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(Guid businessKey, [FromBody] UpdateBusinessCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }
}