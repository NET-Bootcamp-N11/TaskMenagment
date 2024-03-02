using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMenagment.Application.Abstraction.Services.IRepositories;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Infrastructure.BaseRepositories;

namespace TaskMenagment.Infrastructure
{
    public class TaskMenegmentDbContext : DbContext
    {
        public TaskMenegmentDbContext(DbContextOptions<TaskMenegmentDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Programmer> Users { get; set; }
        public virtual DbSet<ProgTask> Tasks { get; set; }
    }
}