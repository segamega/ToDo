namespace Application.Categories.Queries.GetCategoryById
{
    /// <summary>
    /// Ответ на запрос <see cref="GetCategoryByIdRequest"/>.
    /// </summary>
    public class GetCategoryByIdResponse
    {
        /// <summary>
        /// Категория.
        /// </summary>
        public CategoryDto Result { get; set; } = new CategoryDto();
    }
}