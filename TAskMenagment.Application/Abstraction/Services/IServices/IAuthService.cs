using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;

namespace TaskMenagment.Application.AuthServices
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(ProgrammerDTO user);
    }
}
