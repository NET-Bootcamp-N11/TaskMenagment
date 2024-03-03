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

namespace TaskMenagment.Application.Abstraction.Services.ProgrammerServices
{
    public class ProgrammerService : IProgrammerService
    {
        private  readonly IProgrammerRepository _repository;

        public ProgrammerService(IProgrammerRepository programmerRepository)
        {
            _repository = programmerRepository;
        }
        public async Task<Programmer> Create(ProgrammerDTO entity)
        {
            var programmer = new Programmer()
            {
                FullName = entity.FullName,
                About = entity.About,
                Password = entity.Password,
                Username = entity.Username,
                Field = entity.Field,
            };
            var res = await _repository.Create(programmer);
            return res;
        }

        public async Task<bool> Delete(Expression<Func<Programmer, bool>> expression)
        {
            var result = await _repository.Delete(expression);
            return result;
        }

        public async Task<IEnumerable<Programmer>> GetAll()
        {
            var res = await _repository.GetAll();
            return res;
        }

        public async Task<Programmer> GetById(int id)
        {
            var res = await _repository.GetById(x => x.Id == id);
            return res;
        }

        public async Task<Programmer> Update(ProgrammerDTO entity, int id)
        {
            var temp = await _repository.GetById(x => x.Id == id);

            if(temp != null)
            {
                temp.FullName = entity.FullName;
                temp.About = entity.About;
                temp.Password = entity.Password;
                temp.Username = entity.Username;
                temp.Field = entity.Field;
                var res = await _repository.Update(temp);
                return res;
            }
            return null;

        }
    }
}