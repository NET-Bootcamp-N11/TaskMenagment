using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Application.Abstraction.Services.IRepositories;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Domain.Entities.ViewModels;

namespace TaskMenagment.Application.Abstraction.Services.ProgTaskServices
{
    public class ProgTaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public ProgTaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;   
        }
        public async Task<ProgTask> Create(ProgTaskDTO entity)
        {
            var temp = new ProgTask()
            {
                Name = entity.Name,
                Description = entity.Description,
                DeadLine = entity.DeadLine,
                PragrammerId = entity.PragrammerId,
            };
            var res = await _taskRepository.Create(temp);
            return res;
        }

        public Task<bool> Delete(Expression<Func<ProgTask, bool>> expression)
        {
            var res = _taskRepository.Delete(expression);
            return res;
        }

        public Task<IEnumerable<ProgTask>> GetAll()
        {
            var res = _taskRepository.GetAll();
            return res;
        }

        public async Task<ProgTask> GetById(int id)
        {
            var res = await _taskRepository.GetById(x => x.Id == id);
            return res;
        }

        public async Task<ProgTask> Update(ProgTaskDTO entity,int id)
        {
            var temp = await _taskRepository.GetById(x => x.Id == id);

            if (temp != null)
            {
                temp.Name = entity.Name;
                temp.Description = entity.Description;
                temp.DeadLine = entity.DeadLine;
                temp.PragrammerId= entity.PragrammerId;
                var res = await _taskRepository.Update(temp);
                return res;
            }
            return null;
        }
    }
}
