using APIAssesment.Models;
namespace APIAssesment.Interface
{
    public interface IProject
    {
        public Task<IEnumerable<Project>> GetAllProjects();

        public Task<Project> AddProject(Project pro);
    }
}
