namespace Web.App.Models.Dto;


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
    /// Наименование родительской категории.
    /// </summary>
    public string? ParentCategoryName { get; set; }
}