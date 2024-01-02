namespace ApiPagamentos.ValueObjects;

public record VendaVO(
    string Id,
    string Nome,
    decimal Preco,
    string Pagamento,
    int Parcelas,
    DateTime Data
);