using ApiPagamentos.Context;
using ApiPagamentos.Entities;
using ApiPagamentos.Repositories.Base;

namespace ApiPagamentos.Repositories;

public class VendaRepository : BaseRepository<Venda>, IVendaRepository
{
    public VendaRepository(AppDbContext context) : base(context) {}
}