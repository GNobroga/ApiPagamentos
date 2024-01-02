using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPagamentos.Entities.Base;

public class BaseEntity 
{   
    [Key]
    [Column("id")]
    public string? Id { get; set; } = new Guid().ToString();
}