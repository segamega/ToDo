using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Projects.Queries.GetProjectList;

/// <summary>
/// Обработчик запроса <see cref="GetProjectListRequest"/>.
/// </summary>
public class GetProjectListRequestHandler : IRequestHandler<GetProjectListRequest, GetProjectListResponse>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;

    public GetProjectListRequestHandler(IMapper mapper, IProjectRepository projectRepository)
    {
        _mapper = mapper;
        _projectRepository = projectRepository;        
    }

    public async Task<GetProjectListResponse> Handle(GetProjectListRequest request, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAllAsync(cancellationToken);
        return new GetProjectListResponse { Result = _mapper.Map<ProjectDto[]>(projects)};
    }
}