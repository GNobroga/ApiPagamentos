namespace ApiPagamentos.Pagination;

public class PaginationQuery 
{

    private const int LIMIT_SIZE = 50;
    public int Page { get; set; }

    private int _size = 10;

    public int Size { 
        get => _size;
        set {
            _size = value > 50 ? LIMIT_SIZE : value;
        }
    }
}