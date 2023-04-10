namespace Domain.Entities
{
    /// <summary>
    /// Категория.
    /// </summary>
    public class Category
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
        /// Идентификатор родительской категории.
        /// </summary>
        public int? ParentCategoryId { get; set; }

        /// <summary>
        /// Родительская категория.
        /// </summary>
        public Category? ParentCategory { get; set; }
    }
}
