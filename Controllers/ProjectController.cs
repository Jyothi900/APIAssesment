using APIAssesment.Models;
using APIAssesment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace APIAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectservice;

        public ProjectController(ProjectService projectservice)
        {
            _projectservice = projectservice;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAll()
        {
            return Ok(await _projectservice.GetAllProjects());
        }
        [HttpPost]
        public async Task<ActionResult<Project>> AddEmp(Project  p)
        {
            return Ok(await _projectservice.AddProject(p));
        }

    }
}
