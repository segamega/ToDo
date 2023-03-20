using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для объекта Категория.
    /// </summary>
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
