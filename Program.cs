using APIAssesment.Interface;
using APIAssesment.Models;
using Microsoft.EntityFrameworkCore;
using APIAssesment.Service;

namespace APIAssesment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EmployeeContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

            builder.Services.AddScoped<IEmployee, EmployeeService>();
            builder.Services.AddScoped<EmployeeService>();

            builder.Services.AddScoped<IProject, ProjectService>();
            builder.Services.AddScoped<ProjectService>();

            builder.Services.AddScoped<IDepartment, DepartmentService>();
            builder.Services.AddScoped<DepartmentService>();

            builder.Services.AddControllers();

            builder.Services.AddControllers()
                  .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
