using ApiPagamentos.Entities.Base;

namespace ApiPagamentos.Repositories.Base;

public interface IRepository<T> where T : BaseEntity
{
    T Create(T entity);
    T FindById(string id);
    IEnumerable<T> FindAll();

    T Update(T t);

    bool Delete(string id);

    bool Exists(string id);
}