using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {

             if (string.IsNullOrWhiteSpace(employee.RUser.Email) || string.IsNullOrWhiteSpace(employee.RUser.Password))
            {
                throw new ArgumentException("Email and Password are required.");
            }

            // Check if email already exists
            var existingUser = await _userRepository.GetUserByEmail(employee.RUser.Email);
            if (existingUser != null)
            {
                throw new InvalidDataException("Email already in use");
            }
          
            // Hash password before saving
            employee.RUser.Password = BCrypt.Net.BCrypt.HashPassword(employee.RUser.Password);


            // Save user first
            var newUser = await _userRepository.AddUser(employee.RUser);
            employee.RUserID = newUser.RUserID;

            // Save employee
            return await _employeeRepository.AddEmployee(employee);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }
    }
}
