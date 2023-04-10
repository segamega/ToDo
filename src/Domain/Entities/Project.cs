namespace Domain.Entities
{
    /// <summary>
    /// Проект.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория.
        /// </summary>
        public Category? Category { get; set; }
    }
}
