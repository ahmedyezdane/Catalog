namespace Domain.Shadred;

public class PagedList<TData>
{
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
    public List<TData> Data { get; set; } = new();

    public PagedList(List<TData> data, int totalItems, int pageNo, int pageSize)
    {
        Data = data;

        int currentPage = pageNo;
        int startPage = currentPage - 2;
        int endPage = currentPage + 3;

        if (pageSize <= 0)
            pageSize = 20;
        if (pageNo <= 0)
            pageNo = 1;

        int totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);

        if (totalPages <= 0)
            totalPages = 1;

        if (pageNo > totalPages)
            pageNo = totalPages;

        if (startPage <= 0)
        {
            endPage = endPage - (startPage - 1);
            startPage = 1;
        }
        if (endPage > totalPages)
        {
            endPage = totalPages;
            if (endPage > 10)
            {
                startPage = endPage - 4;
            }
        }

        TotalItems = totalItems;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalPages = totalPages;
        StartPage = startPage;
        EndPage = endPage;
    }
}

