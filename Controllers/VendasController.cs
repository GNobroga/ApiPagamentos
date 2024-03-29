using System.Net;
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

    public const string CONTENT_TYPE = "application/json";
    //readonly Jwt jwt;

    readonly IVendaBusiness _vendaBusiness;

    public VendasController(IVendaBusiness vendaBusiness)
    {
        _vendaBusiness = vendaBusiness;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Paginator<VendaVO>), (int) HttpStatusCode.OK)]
    public ActionResult<Paginator<VendaVO>> Get([FromQuery] PaginationQuery query)
    {
        return Ok(Paginator<VendaVO>.GetPaginator(_vendaBusiness.FindAll(), query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(VendaVO), (int) HttpStatusCode.OK)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    public ActionResult<VendaVO> Get([FromRoute] string id)
    {
        return _vendaBusiness.FindById(id);
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

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(VendaVO), (int) HttpStatusCode.OK)]
    public ActionResult<VendaVO> Put([FromRoute] string id, [FromBody] VendaVO vo)
    {
        return _vendaBusiness.Update(id, vo);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    public ActionResult<bool> Delete([FromRoute] string id)
    {
        return _vendaBusiness.Delete(id);
    }
}