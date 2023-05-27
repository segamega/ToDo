using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Контекст для работы с базой данных.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ApplicationContext(
            DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Конфигурация.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        /// <summary>
        /// Категории.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Проекты.
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Задачи.
        /// </summary>
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
    }
}
