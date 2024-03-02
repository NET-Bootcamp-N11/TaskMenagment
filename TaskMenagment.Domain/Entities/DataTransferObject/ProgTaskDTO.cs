using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenagment.Domain.Entities.DataTransferObject
{
    public class ProgTaskDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DeadLine { get; set; }
        public int PragrammerId { get; set; }
    }
}
