namespace Domain.Shadred;

public class BaseSearchDto
{
    public BaseSearchDto(int pageNumber, int pageSize, string filter)
    {
        Filter = filter;

        if (pageNumber < 1)
            PageNumber = 1;
        else
            PageNumber = pageNumber;

        if(pageSize < 1 || 20 < pageSize)
            PageSize = 20;
        else
            PageSize = pageSize;
    }

    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public string Filter { get; init; }
    public int Skip => (PageNumber - 1) * PageSize;
}
