using Application.Tasks.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Tasks.Mappings;

/// <summary>
/// Профиль маппинга для <see cref="Task"/>.
/// </summary>
public class TaskProfile : Profile
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="TaskProfile"/>.
    /// </summary>
    public TaskProfile()
    {
        CreateMap<Task, TaskDto>();
    }
}