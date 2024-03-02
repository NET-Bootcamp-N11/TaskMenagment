using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Application.Abstraction;
using TaskMenagment.Application.Abstraction.Services.ProgrammerServices;
using TaskMenagment.Application.Abstraction.Services.ProgTaskServices;
using TaskMenagment.Application.AuthServices;

namespace TaskMenagment.Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProgrammerService,ProgrammerService>();
            services.AddScoped<ITaskService, ProgTaskService>();
            return services;
        }
    }
}