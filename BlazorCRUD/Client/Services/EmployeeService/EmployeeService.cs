using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public event Action OnChange;

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Department> Departments { get; set; } = new List<Department>();

        private HttpClient _httpClient = null;

        public EmployeeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task GetEmployees()
        {
            var resultTest = await _httpClient.GetFromJsonAsync<object>("https://localhost:44326/api/employees");
            if (resultTest != null) //https://localhost:44326/employees/all
            {
                var test0 = resultTest.ToString();
                var test1 = resultTest.GetType();
                var test2 = resultTest.GetType().Name;
                var test3 = resultTest.GetType().Name;
            }
            var result = await _httpClient.GetFromJsonAsync<List<Employee>>("api/employees");
            if (result != null)
                Console.WriteLine(result);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            if (this.Employees.Any())   // employee collection already in memory, no need to utilize server
                return this.Employees.SingleOrDefault(e => e.ID == id); //omits the request, entity framewrk

            var result = await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
            if (result != null)
                return result;
            throw new Exception("Employee not found");
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var result = await _httpClient.PostAsJsonAsync<Employee>("api/employees", employee);

            var actionResultCode = result.StatusCode;
            if (actionResultCode == System.Net.HttpStatusCode.BadRequest) { } //validation failed

            return await result.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var result = await _httpClient.PutAsJsonAsync<Employee>($"api/employees/{id}", employee);
            return null;
        }

        public async Task DeleteEmployee(int id)
        {
            await _httpClient.DeleteAsync($"api/employees/{id}");
            OnChange.Invoke();
        }

        public async Task GetDepartments()
        {
            // API route not configured in controller layer
            var result = await _httpClient.GetFromJsonAsync<List<Department>>("api/employees/departments");
            if (result != null) this.Departments = result;
        }
    }
}
