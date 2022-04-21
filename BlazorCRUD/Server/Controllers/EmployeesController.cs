using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using BlazorCRUD.Server.Data;
using BlazorCRUD.Shared.DTOs;
using System.Collections.Generic;
//using BlazorCRUD.Shared; // use that with "global" keyword on Program.cs

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly BlazorCRUD.Server.Data.DataContext _context;
        //private readonly MockDatabase _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //[Route("api/employees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees() //=> await _context.Employees.ToListAsync<Employee>();
        {
            var emps = await _context.Employees.Include(e => e.Department).ToListAsync<Employee>();

            foreach (var emp in emps) emp.Department = _context.Departments.Single(d => d.ID == emp.DepartmentID);
            return Ok(emps);
        }
        
        [HttpGet("{id}")] // turns into "/api/employees/{id}
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var empFromDb = await _context.Employees.Include(e => e.Department).SingleOrDefaultAsync(e => e.ID == id);
            empFromDb.Department = _context.Departments.Single(d => d.ID == empFromDb.DepartmentID);

            if (empFromDb == null) return NotFound($"Employee with {id} ID not found.");
            return Ok(empFromDb);
        }

        [HttpPost] //[Route("api/employees/")]        
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            employee.ID = 0;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee); // use DTOs!
        }

        [HttpPut("{id}")] //[Route("api/employees/{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var empFromDb = _context.Employees.SingleOrDefault<Employee>(e => e.ID == id);
            if(empFromDb == null) return NotFound();

            empFromDb.Name = employee.Name;
            empFromDb.Surname = employee.Surname;
            empFromDb.DepartmentID = employee.DepartmentID;
            empFromDb.Salary = employee.Salary;

            await _context.SaveChangesAsync();
            return Ok(empFromDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var empToDelete = await _context.Employees.SingleOrDefaultAsync<Employee>(e => e.ID == id);
            if (empToDelete == null) return NotFound();

            _context.Employees.Remove(empToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("departments")] // turns into "api/employees/departmets"
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return Ok(await _context.Departments.ToListAsync<Department>());
        }
    }
}






/*
 * //context.EMployees.Add(employee); contextx.SaveChanges()
 //public async Task<IActionResult> GetEmployees()
        //public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() => await Ok(emps);        
        //public async Task<ActionResult<List<Employee>>> GetEmployees() => await Ok(emps);
        //public async Task<ActionResult<List<Employee>>> GetEmployees()
        //public async Task<ActionResult<List<Employee>>> GetEmployees() => Ok(emps);*/

//public static List<Department> depts = new List<Department>()
//{
//    new Department(){ID = 1, Location = "Cracow", Name = "IT", YearlyBudget = 10000 },
//    new Department(){ID = 2, Location = "Warsaw", Name = "Finance", YearlyBudget = 5000 },
//    new Department(){ID = 3, Location = "Cracow", Name = "RD", YearlyBudget = 8000 },
//    new Department(){ID = 4, Location = "Warsaw", Name = "Management", YearlyBudget = 7000 }
//};

//public static List<Employee> emps = new List<Employee>()
//{
//    new Employee() { ID = 1, Name = "Forrest", Salary = 5000, Surname="Gump",Department=depts[0], DepartmentID=1 },
//    new Employee() { ID = 2, Name = "Johnny", Salary = 5000, Surname="Bravo",Department=depts[1],DepartmentID=2 }


/*
 foreach (var emp in empDTOs)
    emp.DepartmentDTO = new DepartmentDTO(_context.Departments.Single(d => d.ID == emp.DepartmentID));*/
//};

/**/