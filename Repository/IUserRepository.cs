using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IUserRepository
    {
        Task<RUser> GetUserByEmail(string email);
        Task<RUser> AddUser(RUser user);
    }
}
