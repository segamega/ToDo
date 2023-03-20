using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.UnitOfWorks;

namespace WebApp.Bootstrap
{
    /// <summary>
    /// Расширение коллекций сервисов.
    /// </summary>
    public static class ServiceCollectionExtention
    {
        /// <summary>
        /// Подключение дополнительной функциональности.
        /// </summary>
        /// <param name="services">Коллекция сервисов <see cref="IServiceCollection"/>.</param>
        public static IServiceCollection? UseServices(this IServiceCollection services)
        {
            if (services == null)
            {
                return null;
            }

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
