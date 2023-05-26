using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategories
{
    /// <summary>
    /// Ответ на запрос <see cref="GetCategoriesRequest"/>.
    /// </summary>
    public class GetCategoriesResponse
    {
        /// <summary>
        /// Список категорий.
        /// </summary>
        public ICollection<CategoryDto> Result { get; set; } = new List<CategoryDto>();
    }
}
