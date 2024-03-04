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
        public Task<ProgrammerViewModel> Create(ProgrammerDTO entity);
        public Task<ProgrammerViewModel> GetById(int id);
        public Task<List<ProgrammerViewModel>> GetAll();
        public Task<bool> Delete(Expression<Func<Programmer, bool>> expression);
        public Task<ProgrammerViewModel> Update(ProgrammerDTO entity,int id);
        Task<string> GetPdfPath();
    }
}