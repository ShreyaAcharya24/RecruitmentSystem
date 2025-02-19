using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdDepartment = await _departmentService.AddDepartment(department);
            return CreatedAtAction(nameof(GetById), new { id = createdDepartment.DepartmentID }, createdDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Department department)
        {
            if (id != department.DepartmentID)
                return BadRequest(new { message = "Department Not Found" });

            var updatedDepartment = await _departmentService.UpdateDepartment(department);
            return Ok(updatedDepartment);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _departmentService.DeleteDepartment(id);
            return deleted ? Ok(new { message = "Department deleted successfully." }) : NotFound(new { message = "Department not found." });
        }
    }
}
