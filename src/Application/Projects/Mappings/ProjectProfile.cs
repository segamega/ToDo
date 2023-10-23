using Application.Projects.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Projects.Mappings;

/// <summary>
/// Профиль маппинга для <see cref="Project"/>.
/// </summary>
public class ProjectProfile : Profile
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ProjectProfile"/>.
    /// </summary>
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>();
    }
}