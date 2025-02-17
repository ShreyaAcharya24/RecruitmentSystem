using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Service.Impl
{
    public class PanelService : IPanelService
    {
        private readonly IPanelRepository _repository;

        public PanelService(IPanelRepository repository) => _repository = repository;

        public async Task<IEnumerable<Panel>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Panel> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Panel>> GetInterviewRoundsByEmployeeID(int employeeId) =>
            await _repository.GetInterviewRoundsByEmployeeID(employeeId);

        public async Task AddAsync(PanelDTO panelDTO)
        {
            if (!await _repository.IsValidInterviewRoundID(panelDTO.InterviewRoundID))
                throw new ArgumentException("Invalid Interview Round ID.");

            if (!await _repository.IsValidEmployeeID(panelDTO.InterviewerID))
                throw new ArgumentException("Invalid Employee ID.");

            var panel = new Panel
            {
                InterviewRoundID = panelDTO.InterviewRoundID,
                InterviewerID = panelDTO.InterviewerID
            };

            await _repository.AddAsync(panel);
        }

        public async Task UpdateAsync(int id, PanelDTO panelDTO)
        {
            var existingPanel = await _repository.GetByIdAsync(id);
            if (existingPanel == null)
                throw new KeyNotFoundException("Panel not found.");

            if (!await _repository.IsValidInterviewRoundID(panelDTO.InterviewRoundID))
                throw new ArgumentException("Invalid Interview Round ID.");

            if (!await _repository.IsValidEmployeeID(panelDTO.InterviewerID))
                throw new ArgumentException("Invalid Employee ID.");

            existingPanel.InterviewRoundID = panelDTO.InterviewRoundID;
            existingPanel.InterviewerID = panelDTO.InterviewerID;

            await _repository.UpdateAsync(existingPanel);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
