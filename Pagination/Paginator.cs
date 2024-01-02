namespace ApiPagamentos.Pagination;

public class Paginator<T> : List<T> where T: class 
{

    public Paginator(List<T> items, PaginationQuery query)
    {
        AddRange(items.Skip((query.Page - 1) * query.Size).Take(query.Size));
    }

    public static List<T> GetPaginator(List<T> items, PaginationQuery query)
    {
       return new Paginator<T>(items, query);
    }
}