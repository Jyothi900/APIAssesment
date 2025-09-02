using APIAssesment.Models;
namespace APIAssesment.Interface

{
    public interface IDepartment
    {
        public Task<IEnumerable<Department>> GetAlldept();

        public Task<Department> AddDept(Department Dept);
        public Task<Department> UpdateDept(int id,Department dept);
    }
}
