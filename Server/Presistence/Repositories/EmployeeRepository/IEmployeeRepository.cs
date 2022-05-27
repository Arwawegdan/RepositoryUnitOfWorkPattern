namespace Session.Server
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(Guid id);
        Task<IEnumerable<Employee>> GetAll();
        Task Add(Employee entity);
        Task AddRange(IEnumerable<Employee> employees);
        Task Remove(Guid Id);
        Task<Employee> Edit(Employee entity);
        Task<IEnumerable<Employee>> Search(string searchtext);
    }
}
