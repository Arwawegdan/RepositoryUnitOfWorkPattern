namespace Session.Server;

public class EmployeeRepository : IEmployeeRepository
{
    protected readonly ApplicationDbContext _applicationDbContext;
    internal DbSet<Employee> _dbSet;
    public EmployeeRepository(ApplicationDbContext applocationDbContect)
    {
        this._applicationDbContext = applocationDbContect;
        _dbSet = _applicationDbContext.Set<Employee>();
    }
    public async Task Add(Employee employee)
    {
        _dbSet.Add(employee);
        await _applicationDbContext.SaveChangesAsync();
    }
    public async Task AddRange(IEnumerable<Employee> employees)
    {
        _dbSet.AddRange(employees);
        await _applicationDbContext.SaveChangesAsync();
    }
    public async Task<Employee> Get(Guid id) => await _dbSet.FirstOrDefaultAsync(e => e.Id == id) ?? new Employee();

    public async Task<IEnumerable<Employee>> GetAll() => await _dbSet.ToListAsync();


    public async Task Remove(Guid Id)
    {
        Employee? employeeFromDb = await _dbSet.FirstOrDefaultAsync(e => e.Id == Id);
        if (employeeFromDb == null)
            throw new ArgumentException($"{nameof(employeeFromDb)} was not found");
        _dbSet.Remove(employeeFromDb);
        await _applicationDbContext.SaveChangesAsync();

    }
    public async Task<Employee> Edit(Employee employee)
    {
        if (employee == null || employee.Id == null)
            throw new ArgumentException($"{nameof(employee)} was not provided");
        _dbSet.Update(employee);
        await _applicationDbContext.SaveChangesAsync();
        return await Get(employee.Id.Value);
    }

    public async Task<IEnumerable<Employee>> Search(string searchtext)
    {
        return await _dbSet.Where(e => e.Name.Contains(searchtext)).ToListAsync(); 
        
    }
}
