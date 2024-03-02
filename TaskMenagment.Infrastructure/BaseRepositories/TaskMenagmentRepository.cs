using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Application.Abstraction;
using TaskMenagment.Application.Abstraction.Services.IRepositories;
using TaskMenagment.Domain.Entities.Model;

namespace TaskMenagment.Infrastructure.BaseRepositories
{
    public class TaskMenagmentRepository:BaseRepository<ProgTask>,ITaskRepository
    {
        public TaskMenagmentRepository(TaskMenegmentDbContext context): base(context,context.Set<ProgTask>())
        {
        }
    }
}
