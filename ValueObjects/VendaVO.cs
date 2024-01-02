namespace ApiPagamentos.ValueObjects;

public class VendaVO
{
    public string? Id { get; set; }
    public string? Nome { get; set; }

    public decimal Preco { get; set; }

    public string? Status { get; set; }

    public string? Pagamento { get; set; }

    public DateTime Data { get; set; }

}