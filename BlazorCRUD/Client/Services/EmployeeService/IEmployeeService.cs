namespace BlazorCRUD.Client.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }

        public event Action OnChange;

        /// <summary>
        /// Initializes the Employees parameter with a list of all the employees.
        /// </summary>
        /// <returns></returns>
        public Task GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<Employee> UpdateEmployee(int id, Employee employee);
        public Task DeleteEmployee(int id);

        public Task GetDepartments();
    }
}