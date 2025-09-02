using Microsoft.EntityFrameworkCore;

namespace APIAssesment.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> opt) : base(opt) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeProject> EmployeesProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentID);

            modelBuilder.Entity<Employee>()
               .HasKey(d => d.EmployeeId);

            modelBuilder.Entity<Project>()
                .HasKey(d => d.ProjectID);


            modelBuilder.Entity<EmployeeProject>().
                HasKey(ep=> new {ep.EmployeeId,ep.ProjectId});

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(p => p.Project)
                .WithMany(p=>p.EmployeeProjects)
                .HasForeignKey(p => p.ProjectId);
               
           
        }
       

    }
}
