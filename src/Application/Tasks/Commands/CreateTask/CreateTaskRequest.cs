using System;
using Domain.Enums;

namespace Application.Tasks.Commands.CreateTask;

/// <summary>
/// Запрос для добавления задачи.
/// </summary>
public class CreateTaskRequest
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор проекта.
    /// </summary>
    public int ProjectId { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Срок выполнения.
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Приоритет.
    /// </summary>
    public PriorityType PriorityType { get; set; }
}