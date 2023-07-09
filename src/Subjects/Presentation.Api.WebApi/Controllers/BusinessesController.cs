using Goodtocode.Common.Extensions;
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
public class BusinessesController : BaseController
{
    /// <summary> Get Businesses by Name</summary>
    /// <remarks>
    ///     Sample request:
    ///     "businessName": "My Business"
    ///     "api-version":  1
    /// </remarks>
    /// <returns>Collection of BusinessEntity</returns>
    [HttpGet(Name = "GetBusinessesByNameQuery")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<PagedResult<BusinessEntity>> Get(string name, int pageNumber = 1, int pageSize = 20) => await Mediator.Send(new GetBusinessesByNameQuery
    {
        BusinessName = name,
        Page = pageNumber,
    });

    /// <summary> Get Businesses by Name</summary>
    /// <remarks>
    ///     Sample request:
    ///     "businessName": "My Business"
    ///     "api-version":  1
    /// </remarks>
    /// <returns>Collection of BusinessEntity</returns>
    [HttpGet(Name = "GetBusinessesAllQuery")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<PagedResult<BusinessEntity>> Get(int pageNumber = 1, int pageSize = 20) => await Mediator.Send(new GetBusinessesAllQuery
    {
    });
}