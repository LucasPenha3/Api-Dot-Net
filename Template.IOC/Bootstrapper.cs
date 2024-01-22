using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;
using template.Infra.Contexts;
using template.Infra.Queries;
using template.Infra.Repositories;
using Template.Domain.Commands.Task;
using Template.Domain.Handlers.Task;
using Template.Domain.Interfaces.Handler;
using Template.Domain.Interfaces.Queries;
using Template.Domain.Interfaces.Repositories;

namespace Template.IOC
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Adiciona as dependencias via inversão de controle
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        public static void AddDependeciesIOC(
            this IServiceCollection services,
            IConfiguration configuration,
            Assembly assembly)
        {
            // dbcontext
            //services.AddScoped<DataContext>();
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")); // in Memory
            services.AddDbContext<DataContext>(opt => 
                opt.UseSqlServer(configuration.GetConnectionString("connectionString")));

            // data
            services.AddTransient<ITaskRepository, TaskRepository>();

            services.AddTransient<ITaskQuery, TaskQuery>();
            services.AddTransient<IHealthzQuery, HealthzQuery>();

            // handlers
            services.AddTransient<IHandler<CreateTaskCommand>, CreateTaskHandler>();
            services.AddTransient<IHandler<MarkDoneCommand>, MarkDoneTaskHandler>();
            services.AddTransient<IHandler<MarkUndoneCommand>, MarkUndoneTaskHandler>();
            services.AddTransient<IHandler<UpdateTaskCommand>, UpdateTaskHandler>();
        }
    }
}