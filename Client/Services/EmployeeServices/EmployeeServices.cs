namespace Session.Client;
using System.Linq;
public class EmployeeServices : IEmployeeServices
{ 
    [Inject]
    public HttpClient httpClient { get; set; }

    public async Task<Employee> GetEmployee(Guid id) => await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");

    public async Task<List<Employee>> GetEmployees() => await httpClient.GetFromJsonAsync<List<Employee>>("api/employees");

    public async Task UpdateEmployee(Employee updateEmployee) =>
                        await httpClient.PutAsJsonAsync<Employee>($"api/employees", updateEmployee);
    public async Task CreateEmployee(Employee newEmployee) => 
                        await httpClient.PutAsJsonAsync<Employee>($"api/employees", newEmployee);

    public async Task DeleteEmployee(Guid Id) => await httpClient.DeleteAsync($"api/employees/{Id}");

    public async Task<List<Employee>> Search(string SearchText)
    {
        List<Employee> employees = await httpClient.GetFromJsonAsync<List<Employee>>("api/employees"); 
         return employees.Where(e => e.Name.Contains(SearchText)).ToList();
    }
}