namespace Session.Client.Pages;
public partial class Employees
{
    [Parameter]
    public string SearchText { get; set; }


    [Inject] protected HttpClient? _client { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    Employee employee = new();
    [Parameter]
    public  string empname { get; set; }
    bool showbuttons = false;    
    List<Employee>? employees;
    List<Employee>? newEmployees; 

    protected override async Task OnInitializedAsync() => employees = await GetEmployees();
    protected async Task<List<Employee>> GetEmployees() =>
                                            await _client.GetFromJsonAsync<List<Employee>?>("api/Employees");
    protected async Task OnEditEmployee()
    {
        await _client.PutAsJsonAsync<Employee>("api/employees", employee);
    }

    protected async Task SaveEmployee()
    {
        await _client.PostAsJsonAsync("api/employees", employee);
        employee = new();
        employees = await GetEmployees();
    }

    protected async Task OnDeleteEmployee(Guid? id)
    {
        if (id == null)
            return;
        Employee employee = await _client.GetFromJsonAsync<Employee>($"api/employees/{id}") ?? new();

        if (employee == null)
            return; // you should tost error employee not found in DB

        await _client.DeleteAsync($"api/employees/{employee.Id}");

        employees = await GetEmployees();
    }
    protected async Task<List<Employee>> OnClickSearch()
    {
        employees = await _client.GetFromJsonAsync<List<Employee>>($"api/employees/search/{SearchText}");
      
        return employees;

    }
    private List<Employee> FilteredEmployees
        => employees.Where(e => e.Name != null && e.Name.ToLower().Contains(SearchText.ToLower())).ToList();
}