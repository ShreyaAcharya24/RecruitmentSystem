using Microsoft.VisualBasic;
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

        public async Task<RoundMaster> GetByIdAsync(int id)
        {

            var round = await _repository.GetByIdAsync(id);
            if (round == null)
            {
                throw new KeyNotFoundException($"Master Round with {id} not found");
            }
            return round;
        }

        public async Task AddAsync(RoundMasterDTO roundMasterDTO)
        {
            var existingRounds = await _repository.GetAllAsync();
            if (existingRounds != null && existingRounds.Any(d => string.Equals(d.RoundName, roundMasterDTO.RoundName, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Round name already exists.");


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

            var existingRounds = await _repository.GetAllAsync();
            if (existingRounds != null && existingRounds.Any(d => string.Equals(d.RoundName, roundMasterDTO.RoundName, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Round name already exists.");


            existingRoundMaster.RoundName = roundMasterDTO.RoundName;
            existingRoundMaster.Description = roundMasterDTO.Description;
            existingRoundMaster.IsDefault = roundMasterDTO.IsDefault;

            await _repository.UpdateAsync(existingRoundMaster);
        }

        public async Task DeleteAsync(int id){
            var round= _repository.GetByIdAsync(id);
            if(round == null){
                throw new KeyNotFoundException($"Master Round with id {id} not found");
            }
            await _repository.DeleteAsync(id);
 
        } 
    }
}
