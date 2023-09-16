using System.Collections.Generic;

namespace Application.Categories.Queries.GetCategoryList
{
    /// <summary>
    /// Ответ на запрос <see cref="GetCategoryListRequest"/>.
    /// </summary>
    public class GetCategoryListResponse
    {
        /// <summary>
        /// Список категорий.
        /// </summary>
        public ICollection<CategoryDto> Result { get; set; } = new List<CategoryDto>();
    }
}
