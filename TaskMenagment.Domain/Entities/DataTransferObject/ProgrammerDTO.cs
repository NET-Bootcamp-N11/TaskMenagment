using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenagment.Domain.Enums;

namespace TaskMenagment.Domain.Entities.DataTransferObject
{
    public class ProgrammerDTO
    {
        public string? FullName { get; set; }
        public string? About { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public Field Field { get; set; }
    }
}
