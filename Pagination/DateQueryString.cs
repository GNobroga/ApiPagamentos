using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ApiPagamentos.ValueObjects;
using Microsoft.VisualBasic;

namespace ApiPagamentos.Pagination;

public class VendaDateQueryString : List<VendaVO>
{
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "O {0} não é um data válida")]
    public string? Inicio { get; set; }

    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "O {0} não é um data válida")]
    public string? Fim { get; set; }

    public VendaDateQueryString(IEnumerable<VendaVO> items)
    {
       AddRange(items.Where(item => IsAboveOrEqualsInicio(item.Data) || IsBelowOrEqualsFim(item.Data)));
    }

    private bool IsAboveOrEqualsInicio(DateTime dateTime)
        => string.IsNullOrEmpty(Inicio) || DateOnly.FromDateTime(dateTime) >= ConvertStringToDate(Inicio);
    

    private bool IsBelowOrEqualsFim(DateTime dateTime)
        => string.IsNullOrEmpty(Fim) || DateOnly.FromDateTime(dateTime) <= ConvertStringToDate(Fim);

    private static DateOnly ConvertStringToDate(string value)
    {
        return DateOnly.TryParse(value, out DateOnly result) ? result : 
            throw new Exception("Não foi possível converter de String para DateOnly");
    }

    public static VendaDateQueryString Filter(IEnumerable<VendaVO> items)
    {
        return new VendaDateQueryString(Enumerable.Empty<VendaVO>().ToList());
    }
}