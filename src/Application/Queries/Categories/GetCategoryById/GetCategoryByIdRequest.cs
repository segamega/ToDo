using MediatR;

namespace Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdRequest : IRequest<GetCategoryByIdResponse>
{
    public int Id { get; set; }
}