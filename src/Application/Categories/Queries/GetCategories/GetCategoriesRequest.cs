using MediatR;

namespace Application.Categories.Queries.GetCategories
{
    /// <summary>
    /// Запрос для получения списка категорий с пагинацией.
    /// </summary>
    public class GetCategoriesRequest : IRequest<GetCategoriesResponse>
    {
        public string? Name { get; set; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
