using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var result = await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetById), new { id = result.EmployeeID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest(new { message = "Employee ID mismatch" });
            }

            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }
}
