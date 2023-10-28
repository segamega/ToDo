using MediatR;

namespace Application.Projects.Queries.GetProjectList;

public class GetProjectListRequest : IRequest<GetProjectListResponse> 
{
    public string? Name { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
