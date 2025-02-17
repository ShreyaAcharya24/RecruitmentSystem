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
            return Ok(await _departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            return Ok(await _departmentService.AddDepartment(department));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Department department)
        {
            if (id != department.DepartmentID) return BadRequest();
            return Ok(await _departmentService.UpdateDepartment(department));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _departmentService.DeleteDepartment(id));
        }
    }
}
