namespace ApiPagamentos.Entities.Base;

public class BaseEntity 
{   
    public string? Id { get; set; } = new Guid().ToString();
}