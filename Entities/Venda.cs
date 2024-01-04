using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiPagamentos.Entities.Base;

namespace ApiPagamentos.Entities;

[Table("vendas")]
public class Venda : BaseEntity
{   
    [Column("nome")]
    [Required(ErrorMessage = "O {0} é requirido")]
    public string? Nome { get; set; }

    [Column("preco")]
    [Range(minimum: 1, maximum: 99999, ErrorMessage = "O {0} precisa ter no mínimo {1} e no máximo {2}")]
    public decimal Preco { get; set; }

    [Column("status")]
    [Display(Name = "status")]
    [RegularExpression(@"(processado|pago|falha)", ErrorMessage = "O {0} precisa ter um dos valores: processado | pago | falha")]
    [Required(ErrorMessage = "O {0} é requirido")]
    public string? Status { get; set; }

    [Column("pagamento")]
    [Display(Name = "pagamento")]
    [RegularExpression(@"(cartao|pix|boleto)", ErrorMessage = "O {0} precisa ter um dos valores: cartao | pix | boleto")]
    [Required(ErrorMessage = "O {0} é requirido")]
    public string? Pagamento { get; set; }

    [Column("data")]
    public DateTime Data { get; set; } = DateTime.Now;

}