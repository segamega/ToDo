using Application.Categories.Mappings;
using Application.Categories.Queries.GetCategoryList;
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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var assemblies = new[]
{
                typeof(GetCategoryListRequest).GetTypeInfo().Assembly,
                typeof(GetCategoryListRequestHandler).GetTypeInfo().Assembly,
                typeof(GetCategoryListResponse).GetTypeInfo().Assembly
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
