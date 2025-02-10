using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IUserService
    {
        Task<RUser> GetUserByEmail(string email);
        Task<RUser> AddUser(RUser user);
        bool VerifyPassword(string enteredPassword, string storedHashedPassword);

        Task<string> Login(LoginDTO loginDto);
    }
}
