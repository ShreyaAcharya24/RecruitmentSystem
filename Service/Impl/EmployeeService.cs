using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;
using System.IO;

namespace RecruitmentSystem.Service.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IUserRepository userRepository,IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            return employee;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee details cannot be null.");
            }

             // **** Write validations and remove this from here
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
            var departmentExists = await _departmentRepository.GetDepartmentById(employee.DepartmentID);
            if (departmentExists == null)
                throw new KeyNotFoundException("Department does not exist.");


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
            if (employee == null || employee.EmployeeID == 0)
            {
                throw new ArgumentException("Invalid employee data.");
            }

            var existingEmployee = await _employeeRepository.GetEmployeeById(employee.EmployeeID);
            if (existingEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {employee.EmployeeID} not found.");
            }

            return await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
             var isDeleted  = await _employeeRepository.DeleteEmployee(id);
            if (isDeleted == false)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }

            return true;
        }
    }
}
