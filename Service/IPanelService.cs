using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IPanelService
    {
        Task<IEnumerable<Panel>> GetAllAsync();
        Task<Panel> GetByIdAsync(int id);
        Task<IEnumerable<Panel>> GetInterviewRoundsByEmployeeID(int employeeId);
        Task AddAsync(PanelDTO panelDTO);
        Task UpdateAsync(int id, PanelDTO panelDTO);
        Task DeleteAsync(int id);
    }
}
