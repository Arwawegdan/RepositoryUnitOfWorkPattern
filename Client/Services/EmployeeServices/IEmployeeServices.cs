namespace Session.Client; 
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid Id);
        Task UpdateEmployee(Employee updateEmployee);
        Task CreateEmployee(Employee newEmployee);
        Task DeleteEmployee(Guid Id);
        Task<List<Employee>> Search(string SearchText); 
    }

