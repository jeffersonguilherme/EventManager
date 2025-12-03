namespace EventManager.Domain.Response;

public class PagedResponse<T>
{
    public IEnumerable<T>? Dados { get; set; } = new List<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 3;
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }

    public bool HasNexPage => PageNumber < TotalPages;
    public bool HasPreviouspage => PageNumber > 1 ;

    public PagedResponse(){ }

    public PagedResponse(IEnumerable<T> dados, int pageNumber, int pageSize, int totalItems)
    {
        Dados = dados;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems/(double)pageSize);
    }
}