namespace Session.Server.Presistence.UnitOfWork
{
    public interface IEmployeeUnitOfWork 
    {
        Task Create(Employee employee);

        Task Create(IEnumerable<Employee> entities);

        Task<Employee> Read(Guid id);

        Task<IEnumerable<Employee>> Read();

        Task<Employee> Update(Employee entity);

        Task Delete(Guid id);

        Task<IEnumerable<Employee>> Search(string searchtext);

    }
}
