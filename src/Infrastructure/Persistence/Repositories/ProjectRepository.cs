using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для объекта Проект.
    /// </summary>
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
