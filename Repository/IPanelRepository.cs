using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IPanelRepository
    {
        Task<IEnumerable<Panel>> GetAllAsync();
        Task<Panel> GetByIdAsync(int id);
        Task<IEnumerable<Panel>> GetInterviewRoundsByEmployeeID(int employeeId);
        Task AddAsync(Panel panel);
        Task UpdateAsync(Panel panel);
        Task DeleteAsync(int id);
        Task<bool> IsValidInterviewRoundID(int interviewRoundId);
        Task<bool> IsValidEmployeeID(int employeeId);
    }
}
