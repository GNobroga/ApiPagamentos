using System.Net;
using ApiPagamentos.Authentication;
using ApiPagamentos.Business;
using ApiPagamentos.Pagination;
using ApiPagamentos.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ApiPagamentos.Controllers;

[Produces(CONTENT_TYPE)]
[Consumes(CONTENT_TYPE)]
[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class VendasController : ControllerBase 
{   

    public const string CONTENT_TYPE = "applcation/json";
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
    public ActionResult<VendaDateFilter> GetByRangeDate([FromQuery] VendaDateFilter.QueryString query)
    {
        return VendaDateFilter.ApplyFilter(_vendaBusiness.FindAll(), query);
    }

    [HttpPost]
    [ProducesResponseType(typeof(VendaVO), (int) HttpStatusCode.Created)]
    public ActionResult<VendaVO> Post([FromBody] VendaVO vo)
    {
        return _vendaBusiness.Create(vo);
    }

    [HttpPut]
    [ProducesResponseType(typeof(VendaVO), (int) HttpStatusCode.OK)]
    public ActionResult<VendaVO> Put([FromBody] VendaVO vo)
    {
        return _vendaBusiness.Create(vo);
    }
}