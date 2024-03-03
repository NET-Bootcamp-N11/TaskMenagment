using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenagment.Domain.Enums
{
    public enum Permissions
    {
        CreateProgrammer = 1,
        UpdateProgrammer,
        DeleteProgrammer,
        GetProgrammerById,
        GetProgrammers,
        CreateTask,
        UpdateTask,
        DeleteTask,
        GetTaskById,
        GetTasks,
        ChangePassword
    }
}