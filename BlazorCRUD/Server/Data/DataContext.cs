//using Microsoft.EntityFrameworkCore; //with global in Program.cs

namespace BlazorCRUD.Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData
            (
                    new Department() { ID = 1, Location = "Cracow", Name = "IT", YearlyBudget = 10000 },
                    new Department() { ID = 2, Location = "Warsaw", Name = "Finance", YearlyBudget = 5000 },
                    new Department() { ID = 3, Location = "Cracow", Name = "RD", YearlyBudget = 8000 },
                    new Department() { ID = 4, Location = "Warsaw", Name = "Management", YearlyBudget = 7000 }
            );

            modelBuilder.Entity<Employee>().HasData
            (
                new Employee() { ID = 1, Name = "Forrest", Salary = 5000, Surname = "Gump", DepartmentID = 1 },
                new Employee() { ID = 2, Name = "Jan", Salary = 5000, Surname = "Kowalski", DepartmentID = 2 }
            );
        }
    }
}
// next: appsettings.json: initiate connectionString
// next2: register using builder.Services in Program.cs