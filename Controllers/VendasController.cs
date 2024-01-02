using System.Net;
using ApiPagamentos.Authentication;
using ApiPagamentos.Business;
using ApiPagamentos.Pagination;
using ApiPagamentos.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ApiPagamentos.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class VendasController : ControllerBase 
{   
    readonly Jwt jwt;

    readonly IVendaBusiness _vendaBusiness;

    public VendasController(Jwt jwt, IVendaBusiness vendaBusiness)
    {
        this.jwt = jwt;
        _vendaBusiness = vendaBusiness;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Paginator<VendaVO>), (int) HttpStatusCode.OK)]
    public ActionResult<Paginator<VendaVO>> Get([FromQuery] PaginationQuery query)
    {
        return Ok(Paginator<VendaVO>.GetPaginator(_vendaBusiness.FindAll(), query));
    }

    [HttpGet("search")]
    public ActionResult<string> GetByRangeDate([FromQuery] VendaDateQueryString query)
    {
        return query.Inicio!;
    }

}