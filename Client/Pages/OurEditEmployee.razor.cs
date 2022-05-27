namespace Session.Client.Pages;
    public partial class OurEditEmployee
    {
        [Parameter]
        public string? employeeId { get; set; }

        Employee? employee = new(); 

        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] protected HttpClient _client { get; set; }
        

        protected override async Task OnInitializedAsync() 
                   => employee = await _client.GetFromJsonAsync<Employee>($"api/employees/{employeeId}");

        protected async Task OnEditEmployee()
        { 
            await _client.PutAsJsonAsync<Employee>("api/employees", employee);
            Navigation.NavigateTo("/employees"); 
        }
    }