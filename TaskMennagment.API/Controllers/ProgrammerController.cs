using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using TaskMenagment.Application.Abstraction;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Domain.Enums;
using TaskMennagment.API.Attributes;

namespace TaskMennagment.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProgrammerController : ControllerBase
    {
        private readonly IProgrammerService _programmerService;

        public ProgrammerController(IProgrammerService programmerService)
        {
            _programmerService = programmerService;
        }
        [HttpPost]
        [IdentityFilter(Permissions.CreateProgrammer)]
        public async Task<ActionResult<Programmer>> CreateProgrammer(ProgrammerDTO programmerDTO)
        {
            var result = await _programmerService.Create(programmerDTO);
            return Ok(result);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetProgrammers)]
        public async Task<ActionResult<IEnumerable<Programmer>>> GetAllProgrammers()
        {
            var result = await _programmerService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permissions.GetProgrammerById)]

        public async Task<ActionResult<Programmer>> GetProgrammerById(int id)
        {
            var result = await _programmerService.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdateProgrammer)]

        public async Task<ActionResult<Programmer>> UpdateProgrammer(int id, ProgrammerDTO programmerDTO)
        {
            var result = await _programmerService.Update(programmerDTO, id);
            return Ok(result);
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteProgrammer)]

        public async Task<ActionResult<string>> DeleteProgrammer(int id)
        {
            var result = await _programmerService.Delete(x => x.Id == id);

            if (result)
            {
                return Ok("Deleted");
            }
            return BadRequest("Something went wrong");
        }

        [HttpGet("download")]
        [IdentityFilter(Permissions.GetProgrammerPDF)]
        public async Task<IActionResult> DownloadFile()
        {
            // Replace this with the path to the file you want to download
            var filePath = await _programmerService.GetPdfPath();

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");


            var fileBytes = System.IO.File.ReadAllBytes(filePath);


            var contentType = "application/octet-stream";

            var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();


            // Send the file as a response
            return File(fileBytes, contentType, Path.GetFileName(filePath));
        }

    }
}