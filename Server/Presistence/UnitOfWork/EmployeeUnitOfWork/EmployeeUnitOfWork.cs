namespace Session.Server
{
    public class EmployeeUnitOfWork : IEmployeeUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbcontext;

        private readonly IEmployeeRepository _repository;

        public EmployeeUnitOfWork(ApplicationDbContext context)
        {
            _applicationDbcontext = context;
            _repository = new EmployeeRepository(_applicationDbcontext);
        }
        public async Task Create(Employee employee) => await _repository.Add(employee);

        public async Task Create(IEnumerable<Employee> entities) => await _repository.AddRange(entities);

        public async Task<Employee> Read(Guid id) => await _repository.Get(id);

        public async Task Delete(Guid id) => await _repository.Remove(id);

        public async Task<IEnumerable<Employee>> Read() => await _repository.GetAll();

        public async Task<Employee> Update(Employee entity) => await _repository.Edit(entity);

        public async Task<IEnumerable<Employee>> Search(string searchtext) => await _repository.Search(searchtext);
    }
}
