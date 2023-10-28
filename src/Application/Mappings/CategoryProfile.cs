using Application.Categories.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Categories.Mappings
{
    /// <summary>
    /// Профиль маппинга для <see cref="Category"/>.
    /// </summary>
    public class CategoryProfile : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CategoryProfile"/>.
        /// </summary>
        public CategoryProfile()
        {
            _ = CreateMap<Category, CategoryDto>()
                .ForMember(x => x.ParentCategoryName, opt =>
                {
                    opt.PreCondition(t => t.ParentCategory != null);
                    opt.MapFrom(mapExpression: t => t.ParentCategory!.Name);
                });
        }
    }
}
