using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenagment.Domain.Entities.ViewModels
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProgrammerId { get; set; }
    }
}
