using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IEmployeeSkillRepository
    {
        Task<IEnumerable<EmployeeSkill>> GetAllEmployeeSkills();
        Task<EmployeeSkill> GetEmployeeSkillById(int id);
        Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeId(int employeeId);
        Task<EmployeeSkill> AddEmployeeSkill(EmployeeSkill employeeSkill);
        Task<bool> DeleteEmployeeSkill(int id);
    }
}
