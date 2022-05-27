namespace Session.Client.Pages;

    public partial class Search
{

        [Parameter]
        public string SearchText { get; set; }

        [Inject] protected HttpClient? _client { get; set; }
        

        Employee employee = new();
        List<Employee>? employees;

        
        protected async Task<List<Employee>> GetEmployees() => 
                            await _client.GetFromJsonAsync<List<Employee>>("api/Employees");



    protected async Task OnClickSearch(string? SearchText)
    {   
        Employee employee = await _client.GetFromJsonAsync<Employee>($"api/employees/search{SearchText}");
        employees.Add(employee);    

    }
}

