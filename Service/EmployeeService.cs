using APIAssesment.Interface;
using APIAssesment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;

namespace APIAssesment.Service
{
    public class EmployeeService:IEmployee
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _context.Employees.Include(d=>d.Department).ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }
        public async Task<Employee> AddEmployee(Employee em)
        {
             await _context.Employees.AddAsync(em);
             _context.SaveChangesAsync();
             return em;
        }
        public async Task<Employee> UpdateEmployee(int id,Employee e)
        {
            var exits = await _context.Employees.FirstOrDefaultAsync(e=>e.EmployeeId==id);
            if (exits == null) return null;
           
            exits.Name = e.Name;
            exits.Email = e.Email;
            exits.Role= e.Role;
            await _context.SaveChangesAsync();
            return exits;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            Employee exits = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (exits == null) return false;

            _context.Employees.Remove(exits);
            await _context.SaveChangesAsync();
            return true;
        }
       
        
    }


}

