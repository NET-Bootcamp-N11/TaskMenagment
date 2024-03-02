using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Domain.Entities.ViewModels;

namespace TaskMenagment.Application.Abstraction.Services.ProgTaskServices
{
    public class ProgTaskService : ITaskService
    {
        public Task<ProgTask> Create(ProgTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProgTask> Delete(Expression<Func<ProgTask, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProgTask> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProgTask> Update(ProgTaskDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
