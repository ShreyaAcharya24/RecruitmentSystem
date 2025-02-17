using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Service.Impl
{
    public class RoundMasterService : IRoundMasterService
    {
        private readonly IRoundMasterRepository _repository;

        public RoundMasterService(IRoundMasterRepository repository) => _repository = repository;

        public async Task<IEnumerable<RoundMaster>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<RoundMaster> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(RoundMasterDTO roundMasterDTO)
        {
            var roundMaster = new RoundMaster
            {
                RoundName = roundMasterDTO.RoundName,
                Description = roundMasterDTO.Description,
                IsDefault = roundMasterDTO.IsDefault
            };
            await _repository.AddAsync(roundMaster);
        }

        public async Task UpdateAsync(int id, RoundMasterDTO roundMasterDTO)
        {
            var existingRoundMaster = await _repository.GetByIdAsync(id);
            if (existingRoundMaster == null)
                throw new KeyNotFoundException("Round Master not found.");

            existingRoundMaster.RoundName = roundMasterDTO.RoundName;
            existingRoundMaster.Description = roundMasterDTO.Description;
            existingRoundMaster.IsDefault = roundMasterDTO.IsDefault;

            await _repository.UpdateAsync(existingRoundMaster);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
