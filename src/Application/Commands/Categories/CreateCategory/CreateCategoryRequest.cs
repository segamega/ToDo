using MediatR;

namespace Application.Categories.Commands.CreateCategory;

public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Идентификатор родительской категории.
    /// </summary>
    public int? ParentCategoryId { get; set; }
}