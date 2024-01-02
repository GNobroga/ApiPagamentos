using ApiPagamentos.ValueObjects;

namespace ApiPagamentos.Business;

public interface IVendaBusiness
{
    VendaVO Create(VendaVO vo);

    VendaVO Update(string id, VendaVO vo);

    IEnumerable<VendaVO> FindAll();

}