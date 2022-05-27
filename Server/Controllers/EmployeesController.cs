namespace Session.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        protected readonly IEmployeeUnitOfWork _unitOfWork;

        public EmployeesController(IEmployeeUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task Post([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employee.BirthDate = DateTime.Now.AddYears(-20);

            await _unitOfWork.Create(employee);
        }

        [HttpPost("Bulk")]
        public async Task Post([FromBody] List<Employee> employees) //return void 
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} were not found");
            employees.ForEach(employee =>
            {
                employee.Id = Guid.NewGuid();
                employee.BirthDate = employee.BirthDate.AddYears(-20);
            });
            await _unitOfWork.Create(employees);
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetBulk() => await _unitOfWork.Read();

        [HttpGet("{id}")]
        public async Task<Employee> Get(Guid id) => await _unitOfWork.Read(id);

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee) => await _unitOfWork.Update(employee);

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task DeleteEmployee(Guid id) => await _unitOfWork.Delete(id);

        [HttpGet("Search/{searchtext}")]
        public async Task<IEnumerable<Employee>> Search([FromRoute] string searchtext) => 
                                await _unitOfWork.Search(searchtext); 



    }
}



