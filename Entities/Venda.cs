using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiPagamentos.Entities.Base;

namespace ApiPagamentos.Entities;

[Table("vendas")]
public class Venda : BaseEntity
{
    [Required(ErrorMessage = "O {0} é requirido")]
    public string? Nome { get; set; }

    [Range(minimum: 1, maximum: 99999, ErrorMessage = "O {0} precisa ter no mínimo {1} e no máximo {2}")]
    public decimal Preco { get; set; }

    [Display(Name = "status")]
    [RegularExpression(@"(processando|pago|falha)", ErrorMessage = "O {0} precisa ter um dos valores: processado | pago | falha")]
    public string? Status { get; set; }

    [Display(Name = "pagamento")]
    [RegularExpression(@"(cartao|pix|boleto)", ErrorMessage = "O {0} precisa ter um dos valores: cartao | pix | boleto")]
    public string? Pagamento { get; set; }

}