using System.Collections.Generic;

namespace Application.Tasks.Queries.GetTaskList
{
    /// <summary>
    /// Ответ на запрос <see cref="GetTaskListRequest"/>.
    /// </summary>
    public class GetTaskListResponse
    {
        /// <summary>
        /// Список категорий.
        /// </summary>
        public ICollection<TaskDto> Result { get; set; } = new List<TaskDto>();
    }
}
