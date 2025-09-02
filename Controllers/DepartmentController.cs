using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIAssesment.Service;
using APIAssesment.Models;

namespace APIAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            return Ok(await _departmentService.GetAlldept());
        }
        [HttpPost]
        public async Task<ActionResult<Department>> AddDept(Department dept)
        {
            return Ok(await _departmentService.AddDept(dept));
        }
        [HttpPut]
        public async Task<ActionResult<Department>> UpdateDept(int id,Department dept)
        {
            return Ok(await _departmentService.UpdateDept(id, dept));
        }
    }
}
