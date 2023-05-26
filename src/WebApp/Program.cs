using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApp.Bootstrap;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.UseServices();

            var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection,
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}