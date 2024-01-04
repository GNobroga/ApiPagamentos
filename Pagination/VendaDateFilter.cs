using System.ComponentModel.DataAnnotations;
using ApiPagamentos.ValueObjects;

namespace ApiPagamentos.Pagination;

public class VendaDateFilter : List<VendaVO>
{
    readonly string _inicio;
    readonly string _fim;

    public class QueryString 
    {
        [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "O {0} não é um data válida")]
        public string? Inicio { get; set; }

        [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "O {0} não é um data válida")]
        public string? Fim { get; set; }
    }

    private VendaDateFilter(IEnumerable<VendaVO> items, QueryString query)
    {
        _inicio = query.Inicio!;
        _fim = query.Fim!;

        if (!string.IsNullOrEmpty(_inicio) && !string.IsNullOrEmpty(_fim)) {
            var dateOnlyInicio = ConvertStringToDate(_inicio);
            var dateOnlyFim = ConvertStringToDate(_fim);

            if (dateOnlyInicio > dateOnlyFim) 
                throw new ApplicationException("A data início não pode ser maior que a data fim");
            
            if (dateOnlyFim < dateOnlyInicio) 
                throw new ApplicationException("A datafim não pode ser menor que a data inicio");
        }


       AddRange(items.Where(item => IsAboveOrEqualsInicio(item.Data) && IsBelowOrEqualsFim(item.Data)));
    }

    private bool IsAboveOrEqualsInicio(DateTime dateTime)
        => string.IsNullOrEmpty(_inicio) || DateOnly.FromDateTime(dateTime) >= ConvertStringToDate(_inicio);
    

    private bool IsBelowOrEqualsFim(DateTime dateTime)
        => string.IsNullOrEmpty(_fim) || DateOnly.FromDateTime(dateTime) <= ConvertStringToDate(_fim);

    private static DateOnly ConvertStringToDate(string value)
    {
        return DateOnly.TryParse(value, out DateOnly result) ? result : 
            throw new Exception("Não foi possível converter de String para DateOnly");
    }

    public static VendaDateFilter ApplyFilter(IEnumerable<VendaVO> items, QueryString query)
    {
        return new VendaDateFilter(items, query);
    }
}