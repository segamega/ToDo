using MediatR;

namespace Application.Categories.Queries.GetCategoryList
{
    /// <summary>
    /// Запрос для получения списка категорий с пагинацией.
    /// </summary>
    public class GetCategoryListRequest : IRequest<GetCategoryListResponse>
    {
        public string? Name { get; set; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
