using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;

        public EmployeeSkillService(IEmployeeSkillRepository employeeSkillRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
        }

        public async Task<IEnumerable<EmployeeSkill>> GetAllEmployeeSkills() => await _employeeSkillRepository.GetAllEmployeeSkills();


        public async Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeId(int employeeId) => await _employeeSkillRepository.GetSkillsByEmployeeId(employeeId);

        public async Task<EmployeeSkill> AddEmployeeSkill(EmployeeSkill employeeSkill) => await _employeeSkillRepository.AddEmployeeSkill(employeeSkill);

        public async Task<bool> DeleteEmployeeSkill(int id) => await _employeeSkillRepository.DeleteEmployeeSkill(id);

        public async Task<EmployeeSkill> GetEmployeeSkillById(int id) => await _employeeSkillRepository.GetEmployeeSkillById(id);
        
    }
}
