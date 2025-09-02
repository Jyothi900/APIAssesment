using APIAssesment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIAssesment.Models;

namespace APIAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return Ok(await _employeeService.GetAllEmployee());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmp(Employee e)
        {
            return Ok(await _employeeService.AddEmployee(e));
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmp(int id, Employee e)
        {
            return Ok(await _employeeService.UpdateEmployee(id, e));
        }
        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmp(int id)
        {
            return Ok(await _employeeService.DeleteEmployee(id));
        }
    }
}
