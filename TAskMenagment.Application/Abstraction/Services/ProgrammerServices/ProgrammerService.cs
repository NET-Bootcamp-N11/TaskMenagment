using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Domain.Entities.ViewModels;

namespace TaskMenagment.Application.Abstraction.Services.ProgrammerServices
{
    public class ProgrammerService : IProgrammerService
    {
        public Task<Programmer> Create(Programmer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Programmer> Delete(Expression<Func<Programmer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProgrammerViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Programmer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Programmer> Update(ProgrammerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
