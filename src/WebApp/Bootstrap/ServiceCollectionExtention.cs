using Application.Categories.Mappings;
using Application.Categories.Queries.GetCategories;
using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

            var assemblies = new[]
{
                typeof(GetCategoriesRequest).GetTypeInfo().Assembly,
                typeof(GetCategoriesRequestHandler).GetTypeInfo().Assembly,
                typeof(GetCategoriesResponse).GetTypeInfo().Assembly
            };

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
