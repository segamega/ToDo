using Domain.Enums;
using MediatR;
using System;

namespace Application.Tasks.Queries.GetTaskList
{
    /// <summary>
    /// Запрос для получения списка заметок.
    /// </summary>
    public class GetTaskListRequest : IRequest<GetTaskListResponse>
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Начало диапазона даты и времени создания заметки.
        /// </summary>
        public DateTime? CreatedDateFrom { get; set; }

        /// <summary>
        /// Окончание диапазона даты и времени создания заметки.
        /// </summary>
        public DateTime? CreatedDateTo { get; set; }

        /// <summary>
        /// Начало диапазона даты и времени последнего редактирования заметки.
        /// </summary>
        public DateTime? UpdatedDateFrom { get; set; }

        /// <summary>
        /// Окончание диапазона даты и времени последнего редактирования заметки.
        /// </summary>
        public DateTime? UpdatedDateTo { get; set; }

        /// <summary>
        /// Начало диапазона срока выполнения.
        /// </summary>
        public DateTime? DueDateFrom { get; set; }

        /// <summary>
        /// Окончание диапазона срока выполнения.
        /// </summary>
        public DateTime? DueDateTo { get; set; }

        /// <summary>
        /// Приоритет.
        /// </summary>
        public PriorityType? PriorityType { get; set; }
    }
}
