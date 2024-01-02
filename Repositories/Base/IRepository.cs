using ApiPagamentos.Entities.Base;

namespace ApiPagamentos.Repositories.Base;

public interface IRepository<T> where T: BaseEntity
{
    T Create(T entity);
    IEnumerable<T> FindAll();

    T Update(T t);

    bool Delete(long id);

    bool Exists(long id);
}