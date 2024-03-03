using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMenagment.Application.Abstraction;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Domain.Enums;
using TaskMennagment.API.Attributes;

namespace TaskMennagment.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost]
        [IdentityFilter(Permissions.CreateTask)]
        public async Task<ActionResult<Programmer>> CreateTask(ProgTaskDTO taskDTO)
        {
            var result = await _taskService.Create(taskDTO);
            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetTasks)]
        public async Task<ActionResult<IEnumerable<ProgTask>>> GetAllTasks ()
        {
            var result = await _taskService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetTaskById)]

        public async Task<ActionResult<ProgTask>> GetTaskById(int id)
        {
            var result = await _taskService.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdateProgrammer)]

        public async Task<ActionResult<ProgTask>> UpdateTAsk(int id, ProgTaskDTO taskDTO)
        {
            var result = await _taskService.Update(taskDTO, id);
            return Ok(result);
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteTask)]

        public async Task<ActionResult<string>> DeleteTask(int id)
        {
            var result = await _taskService.Delete(x => x.Id == id);

            if (result)
            {
                return Ok("Deleted");
            }
            return BadRequest("Something went wrong");
        }
    }
}
