using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Application.Abstraction.Services.IRepositories;
using TaskMenagment.Infrastructure.BaseRepositories;

namespace TaskMenagment.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<TaskMenegmentDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IProgrammerRepository, ProgrammerRepository>();
            services.AddScoped<ITaskRepository, TaskMenagmentRepository>();
            return services;
        }
    }
}