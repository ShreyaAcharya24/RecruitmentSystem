using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;


namespace RecruitmentSystem.Repository.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<Department> AddDepartment(Department department)
        {

            if (await _context.Departments.AnyAsync(d => d.DepartmentName == department.DepartmentName))
            {
                throw new Exception("Department name already exists.");
            }
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartment(Department department)
        {

            var existingDepartment = await _context.Departments.FindAsync(department.DepartmentID);
            if (existingDepartment == null)
                throw new Exception("Department not found.");

            if (await _context.Departments.AnyAsync(d => d.DepartmentName == department.DepartmentName && d.DepartmentID != department.DepartmentID))
            {
                throw new Exception("Department name already exists.");
            }
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                throw new Exception("Department not found.");

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
