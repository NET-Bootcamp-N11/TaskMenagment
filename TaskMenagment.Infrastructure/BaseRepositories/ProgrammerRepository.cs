using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Application.Abstraction.Services.IRepositories;
using TaskMenagment.Domain.Entities.Model;

namespace TaskMenagment.Infrastructure.BaseRepositories
{
    public class ProgrammerRepository:BaseRepository<Programmer>, IProgrammerRepository
    {
        public ProgrammerRepository(TaskMenegmentDbContext context) : base(context,context.Set<Programmer>())
        {
        }
    }
}
