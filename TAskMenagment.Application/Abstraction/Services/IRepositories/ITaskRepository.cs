using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Entities.Model;

namespace TaskMenagment.Application.Abstraction.Services.IRepositories
{
    public interface ITaskRepository : IBaseRepository<ProgTask>
    {
    }
}
