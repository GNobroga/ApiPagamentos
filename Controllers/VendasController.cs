using ApiPagamentos.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiPagamentos.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class VendasController : ControllerBase 
{   
    readonly Jwt jwt;

    public VendasController(IOptions<Jwt> opt)
    {
        jwt = opt.Value;
    }

    [HttpGet]
    public string GetPublic() 
    {
        Console.WriteLine(jwt.GenerateToken("ADMIN"));
        return "jwt.Issuer!";
    }

    [Authorize(Roles = "DEV")]
    [HttpGet("private")]
    public string GetPrivate() 
    {
        return "Private";
    }
}