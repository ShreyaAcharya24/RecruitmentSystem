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
    public async Task<Skill> GetSkillById(int id)
    {
        var skill = await _repository.GetSkillById(id);
        if (skill == null)
        {
            throw new KeyNotFoundException("Skill Not found");
        }
        return skill;
    }

    public async Task<Skill> AddSkill(Skill skill)
    {
        var existingSkills = await _repository.GetAllSkills();
        if (existingSkills.Any(s => string.Equals(s.SkillName, skill.SkillName, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("Skill name already exists.");
        return await _repository.AddSkill(skill);
    }

    public async Task<Skill> UpdateSkill(Skill skill)
    {
        var existingSkill = await _repository.GetSkillById(skill.SkillID);
        if (existingSkill == null)
            throw new KeyNotFoundException("Skill not found.");

        var allSkills = await _repository.GetAllSkills();
        if (allSkills.Any(s => s.SkillName == skill.SkillName && s.SkillID != skill.SkillID))
            throw new InvalidOperationException("Skill name already exists.");

        return await _repository.UpdateSkill(skill);
    }
    public async Task<bool> DeleteSkill(int id)
    {
        var skill = await _repository.GetSkillById(id);
        if (skill == null)
            throw new KeyNotFoundException("Skill not found.");

        return await _repository.DeleteSkill(id);
    }

    public async Task<bool> DoesSkillExistAsync(int id)
    {
        return await _repository.SkillExistsAsync(id);
    }
}
