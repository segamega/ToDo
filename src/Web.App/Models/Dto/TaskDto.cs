using Web.App.Models.Enum;

namespace Web.App.Models.Dto
{
    /// <summary>
    /// Задача.
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public int ProjectName { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Срок выполнения.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Приоритет.
        /// </summary>
        public PriorityType PriorityType { get; set; }
    }
}
