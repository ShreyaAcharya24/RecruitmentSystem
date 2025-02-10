using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
