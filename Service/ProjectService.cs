using APIAssesment.Interface;
using APIAssesment.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAssesment.Service
{
    public class ProjectService:IProject
    {
        private readonly EmployeeContext _context;
        public ProjectService(EmployeeContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _context.Projects.Include(p=>p.EmployeeProjects).ToListAsync();
        }
        public async Task<Project> AddProject(Project p)
        {
            await _context.Projects.AddAsync(p);
            await _context.SaveChangesAsync();
            return p;
        }
    }
}
