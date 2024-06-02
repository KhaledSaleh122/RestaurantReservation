using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Employee;
using RestaurantReservation.Db;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "Manager")]
    [Route("api/restaurants/employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _repository;
        private readonly RestaurantRepository _restaurantRepository;
        private readonly OrderRepository orderRepository;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeRepository repository, RestaurantRepository restaurantRepository, OrderRepository orderRepository)
        {
            _repository = repository;
            _restaurantRepository = restaurantRepository;
            this.orderRepository = orderRepository;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<EmployeeCreateDto, Employee>();
                cfg.CreateMap<EmployeeDto, Employee>();
            });
            _mapper = configuration.CreateMapper();
        }
        [HttpGet("/api/restaurants/employees/{employeeId}/average-order-amount")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAvargeOrderAmountForEmployee(int employeeId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var employee = await _repository.GetEmployee(restaurantId, employeeId);
            if (employee is null)
            {
                return NotFound();
            }
            var orders = await orderRepository.GetAllOrdersForEmployee(employeeId);
            var avarage = orders.Average(p => p.Total_amount);
            return Ok(avarage);
        }


        [HttpGet("/api/restaurants/employees/managers")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetManagers()
        {
            var employees = await _repository.GetAllManagers();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var employees = await _repository.GetAllEmployees(restaurantId);
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }


        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int employeeId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var employee = await _repository.GetEmployee(restaurantId, employeeId);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeCreateDto employeeinfo)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var employee = _mapper.Map<Employee>(employeeinfo);
            employee.RestaurantId = restaurantId;
            var EmployeeInfo = await _repository.CreateEmployeeAsync(employee);
            return Ok(_mapper.Map<EmployeeDto>(EmployeeInfo));
        }

        [HttpPut("{employeeId}")]
        public async Task<ActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeCreateDto Employeeinfo)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var Employee = await _repository.GetEmployee(restaurantId, employeeId);
            if (Employee is null)
            {
                return NotFound();
            }
            _mapper.Map(Employeeinfo, Employee);
            await _repository.UpdateEmployeeAsync(Employee);
            return Ok();
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var employee = await _repository.GetEmployee(restaurantId, employeeId);
            if (employee is null)
            {
                return NotFound();
            }
            await _repository.DeleteEmployeeAsync(employeeId);
            return Ok();
        }

    }
}
