using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IEmployeeSkillService
    {
        Task<IEnumerable<EmployeeSkill>> GetAllEmployeeSkills();
        Task<EmployeeSkill> GetEmployeeSkillById(int id);
        Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeId(int employeeId);
        Task<EmployeeSkill> AddEmployeeSkill(EmployeeSkill employeeSkill);
        Task<bool> DeleteEmployeeSkill(int id);
    }
}
