using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _repository;

    public SkillService(ISkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Skill>> GetAllSkills() => await _repository.GetAllSkills();
    public async Task<Skill> GetSkillById(int id) => await _repository.GetSkillById(id);
    public async Task<Skill> AddSkill(Skill skill) => await _repository.AddSkill(skill);
    public async Task<Skill> UpdateSkill(Skill skill) => await _repository.UpdateSkill(skill);
    public async Task<bool> DeleteSkill(int id) => await _repository.DeleteSkill(id);

     public async Task<bool> DoesSkillExistAsync(int id)
        {
            return await _repository.SkillExistsAsync(id);
        }
}
