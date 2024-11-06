namespace Contacts.Application.Helpers.Pagination;

public record PaginatedQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}