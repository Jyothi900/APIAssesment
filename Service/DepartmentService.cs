using APIAssesment.Interface;
using APIAssesment.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAssesment.Service
{
    public class DepartmentService:IDepartment
    {
        private readonly EmployeeContext _context;

        public DepartmentService(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAlldept()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<Department> AddDept(Department department)
        {
             await _context.Departments.AddAsync(department);
             await _context.SaveChangesAsync();
             return department;

        }
        public async Task<Department> UpdateDept(int id,Department dept)
        {
            var exists = await _context.Departments.FirstOrDefaultAsync(d=>d.DepartmentID == id);
            if (exists == null) return null;
            exists.Location = dept.Location;
            exists.Name = dept.Name;
            await _context.SaveChangesAsync();
            return dept;
        }
    }
}
