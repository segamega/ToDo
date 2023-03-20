using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для объекта Задача.
    /// </summary>
    public class TaskRepository : GenericRepository<Domain.Entities.Task>, ITaskRepository
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public TaskRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
