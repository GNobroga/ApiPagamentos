using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPagamentos.Entities.Base;

public class BaseEntity 
{   
    public Guid Id { get; set; }
}