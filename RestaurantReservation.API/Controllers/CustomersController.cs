using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Customer;
using RestaurantReservation.Db;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "Manager")]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly CustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(CustomerRepository repository)
        {
            _repository = repository;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerCreateDto, Customer>();
            });
            _mapper = configuration.CreateMapper();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _repository.GetAllCustomer();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }


        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int customerId)
        {
            var customer = await _repository.GetCustomer(customerId);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CustomerCreateDto customer)
        {

            var customerInfo = await _repository.CreateCustomerAsync(_mapper.Map<Customer>(customer));
            return Ok(_mapper.Map<CustomerDto>(customerInfo));
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(int customerId, [FromBody] CustomerCreateDto customerinfo)
        {

            var customer = await _repository.GetCustomer(customerId);
            if (customer is null)
            {
                return NotFound();
            }
            _mapper.Map(customerinfo, customer);
            await _repository.UpdateCustomerAsync(customer);
            return Ok();
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer(int customerId)
        {
            var customer = await _repository.GetCustomer(customerId);
            if (customer is null)
            {
                return NotFound();
            }
            await _repository.DeleteCustomerAsync(customerId);
            return Ok();
        }

    }
}
