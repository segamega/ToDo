using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Projects = new ProjectRepository(_context);
            Tasks = new TaskRepository(_context);
        }

        /// <summary>
        /// Категории.
        /// </summary>
        public ICategoryRepository Categories { get; private set; }

        /// <summary>
        /// Проекты.
        /// </summary>
        public IProjectRepository Projects { get; private set; }

        /// <summary>
        /// Задачи.
        /// </summary>
        public ITaskRepository Tasks { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int SaveChangesAsync()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
