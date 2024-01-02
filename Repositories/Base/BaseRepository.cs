using ApiPagamentos.Context;
using ApiPagamentos.Entities.Base;

namespace ApiPagamentos.Repositories.Base;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public T Create(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Delete(string id)
    {
        if (Exists(id)) {
            var entity = _context.Find<T>(id)!;
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }
        return false;
    }

    public bool Exists(string id)
    {
        return _context.Find<T>(id) is not null;
    }

    public IEnumerable<T> FindAll()
    {
       return _context.Set<T>().ToList();
    }

    public T FindById(string id)
    {
        return _context.Find<T>(id)!;
    }

    public T Update(T t)
    {
        _context.Update(t);
        _context.SaveChanges();
        return t;
    }
}