using ApiPagamentos.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPagamentos.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Venda> Vendas { get; set; }

}