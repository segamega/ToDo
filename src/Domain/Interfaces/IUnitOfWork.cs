using System;

namespace Domain.Interfaces
{
    /// <summary>
    /// Интерфейс обеспечения атомарности операций.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Категории.
        /// </summary>
        ICategoryRepository Categories { get; }

        /// <summary>
        /// Проекты.
        /// </summary>
        IProjectRepository Projects { get; }

        /// <summary>
        /// Задачи.
        /// </summary>
        ITaskRepository Tasks { get; }

        /// <summary>
        /// Функция завершения операций.
        /// </summary>
        /// <returns></returns>
        int SaveChangesAsync();
    }
}
