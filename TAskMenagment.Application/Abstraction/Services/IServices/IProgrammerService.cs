using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Domain.Entities.ViewModels;

namespace TaskMenagment.Application.Abstraction
{
    public interface IProgrammerService
    {
        public Task<Programmer> Create(Programmer entity);
        public Task<Programmer> GetById(int id);
        public Task<IEnumerable<ProgrammerViewModel>> GetAll();
        public Task<Programmer> Delete(Expression<Func<Programmer, bool>> expression);
        public Task<Programmer> Update(ProgrammerDTO entity);
    }
}