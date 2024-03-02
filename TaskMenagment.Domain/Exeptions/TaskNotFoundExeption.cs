using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenagment.Domain.Exeptions
{
    public class TaskNotFoundExeption : Exception
    {
        public TaskNotFoundExeption():base("TaskNotFound") { }
    }
}
