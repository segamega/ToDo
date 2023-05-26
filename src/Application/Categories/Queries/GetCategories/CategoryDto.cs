using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategories
{
    /// <summary>
    /// Категория.
    /// </summary>
    public class CategoryDto
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
        public string? ParentCategoryName { get; set; }
    }
}
