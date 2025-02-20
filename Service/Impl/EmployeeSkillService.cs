using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;

        private readonly IEmployeeRepository _employeeRepository;


        public EmployeeSkillService(IEmployeeSkillRepository employeeSkillRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
        }

        public async Task<IEnumerable<EmployeeSkill>> GetAllEmployeeSkills() => await _employeeSkillRepository.GetAllEmployeeSkills();


        public async Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeId(int employeeId)
        {

            var employee = _employeeSkillRepository.GetSkillsByEmployeeId(employeeId);
            if (employee == null)
                throw new KeyNotFoundException($"Employee with {employeeId} Doesn't exist");

            return await _employeeSkillRepository.GetSkillsByEmployeeId(employeeId);
        }

        public async Task<EmployeeSkill> AddEmployeeSkill(EmployeeSkill employeeSkill) => await _employeeSkillRepository.AddEmployeeSkill(employeeSkill);

        public async Task<bool> DeleteEmployeeSkill(int id)
        {
            var employeeSkill = await _employeeSkillRepository.GetEmployeeSkillById(id);
            if (employeeSkill == null)
            {
                throw new KeyNotFoundException($"EmployeeSkill with id {id} doesn't exist");

            }

            return await _employeeSkillRepository.DeleteEmployeeSkill(id);
        }

        public async Task<EmployeeSkill> GetEmployeeSkillById(int id) {
            var employeeSkill = await _employeeSkillRepository.GetEmployeeSkillById(id);
            if (employeeSkill == null)
                throw new KeyNotFoundException($"Employee Skill with {id} doesn't exist");
            return employeeSkill;
        } 
    }
}
