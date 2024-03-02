using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Enums;

namespace TaskMenagment.Domain.Entities.ViewModels
{
    public class ProgrammerViewModel
    {
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public Field Field { get; set; }
    }
}
