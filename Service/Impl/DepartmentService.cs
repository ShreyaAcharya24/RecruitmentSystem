using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAllDepartments();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetDepartmentById(id);
            if (department == null)
                throw new KeyNotFoundException("Department not found.");

            return department;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            var existingDepartments = await _departmentRepository.GetAllDepartments();
            if (existingDepartments.Any(d => string.Equals(d.DepartmentName, department.DepartmentName, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Department name already exists.");

            return await _departmentRepository.AddDepartment(department);

        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var existingDepartment = await _departmentRepository.GetDepartmentById(department.DepartmentID);
            if (existingDepartment == null)
                throw new KeyNotFoundException("Department not found.");

            var allDepartments = await _departmentRepository.GetAllDepartments();
            if (allDepartments.Any(d => d.DepartmentName == department.DepartmentName && d.DepartmentID != department.DepartmentID))
                throw new InvalidOperationException("Department name already exists.");

            return await _departmentRepository.UpdateDepartment(department);

        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartmentById(id);
            if (department == null)
                throw new KeyNotFoundException("Department not found.");

            return await _departmentRepository.DeleteDepartment(id);
        }
    }
}

/*
const createDepartment = async (departmentData) => {
  try {
    const response = await fetch("http://localhost:5000/api/Department", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(departmentData),
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message || "Something went wrong!");
    }

    alert("Department added successfully!");
  } catch (error) {
    console.error(error.message);
    alert(error.message); // Show error message in UI
  }
};


*/


