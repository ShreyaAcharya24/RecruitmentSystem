using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RUser> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<RUser> AddUser(RUser user)
        {
            // Check if email already exists
            var existingUser = await _userRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already in use");
            }

            // Hash password before saving
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            return await _userRepository.AddUser(user);
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }

        public async Task<string> Login(LoginDTO loginDto){

            var user = await _userRepository.GetUserByEmail(loginDto.Email);
            if(user == null || !VerifyPassword(loginDto.Password,user.Password)){

                throw new UnauthorizedAccessException("Invalid Credentials ");
            }

            return user.Role switch {
                UserRole.Admin => "Welcome, Admin!",
                UserRole.Candidate => "Welcome, Candidate",
                UserRole.HR => "Welcome, HR",
                UserRole.Employee => "Welcome, Employee",
                _=> "Welcome, User!"
            };

        }
    }
}
