using System.Xml;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Repository.Impl;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class JobSkillService : IJobSkillService
    {
        private readonly IJobSkillRepository _jobSkillRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ISkillRepository _skillRepository;

        public JobSkillService(IJobSkillRepository jobSkillRepository, IJobRepository jobRepository, ISkillRepository skillRepository)
        {
            _jobSkillRepository = jobSkillRepository;
            _jobRepository = jobRepository;
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<JobSkill>> GetAllJobSkills() => await _jobSkillRepository.GetAllJobSkills();

        public async Task<JobSkill> GetJobSkillById(int id)
        {
            var jobSkill = await _jobSkillRepository.GetJobSkillById(id);
            if (jobSkill == null)
            {
                throw new KeyNotFoundException($"JobSkill with Id {id} doesn't exist");
            }
            return jobSkill;
        }

        public async Task<IEnumerable<JobSkill>> GetJobSkillsByJobId(int jobId)
        {
            var job = _jobRepository.GetJobById(jobId);
            if (job == null)
                throw new KeyNotFoundException("$ Job with {jobId} Doesn't exist");

            return await _jobSkillRepository.GetJobSkillsByJobId(jobId);
        }

        public async Task<JobSkill> AddJobSkill(JobSkill jobSkill)
        {

            var job = await _jobRepository.GetJobById(jobSkill.JobID);
            if (job == null)
                throw new KeyNotFoundException("Job does not exist.");
            
            jobSkill.Job = job;

            var skillExists = await _skillRepository.GetSkillById(jobSkill.SkillID);
            if (skillExists == null)
                throw new KeyNotFoundException("Skill does not exist.");
            
            jobSkill.Skill = skillExists;

            var existingSkills = await _jobSkillRepository.GetJobSkillsByJobId(jobSkill.JobID);
            foreach (var js in existingSkills)
            {
                if (js.SkillID == jobSkill.SkillID)
                {
                    throw new InvalidOperationException("This job already has this skill assigned.");
                }
            }
            return await _jobSkillRepository.AddJobSkill(jobSkill);
        }

        public async Task<bool> DeleteJobSkill(int id) {
            var jobSkill = await _jobSkillRepository.GetJobSkillById(id);
            if(jobSkill== null){
                throw new KeyNotFoundException($"JobSkill with id {id} doesn't exist");

            }
            return await _jobSkillRepository.DeleteJobSkill(id);
            
        } 
    }
}
