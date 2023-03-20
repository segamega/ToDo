namespace Domain.Entities
{
    /// <summary>
    /// Задача.
    /// </summary>
    public class Task
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
        /// Дата и время создания.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата и время последнего редактирования заметки.
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Дата и время удаления.
        /// </summary>
        public DateTime DeletedDate { get; set; }
    }
}
