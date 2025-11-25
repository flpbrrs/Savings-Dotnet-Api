namespace Savings.Domain.ValueObjects;

public class Pagination
{
    public int Page { get; }
    public int PageSize { get; }

    public Pagination(int page = 1, int pageSize = 10)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        Page = page;
        PageSize = pageSize;
    }
}
