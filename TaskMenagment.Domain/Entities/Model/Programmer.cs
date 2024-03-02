using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Enums;

namespace TaskMenagment.Domain.Entities.Model
{
    public class Programmer
    {
        public int Id { get; set; }
        public string FullaName { get; set; }
        public string About{ get; set; }
        public Field Field { get; set; }
    }
}
