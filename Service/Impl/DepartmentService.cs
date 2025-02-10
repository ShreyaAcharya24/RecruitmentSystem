using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAllDepartments();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentRepository.GetDepartmentById(id);
        }

        public async Task<Department> AddDepartment(Department department)
        {
            return await _departmentRepository.AddDepartment(department);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            return await _departmentRepository.UpdateDepartment(department);
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            return await _departmentRepository.DeleteDepartment(id);
        }
    }
}
