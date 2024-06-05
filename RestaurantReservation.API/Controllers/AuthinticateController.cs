using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Models.Authinticate;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthinticateController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly EmployeeRepository employeeRepository;
        private readonly IConfiguration configuration;

        public AuthinticateController(CustomerRepository customerRepository, EmployeeRepository employeeRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            this.employeeRepository = employeeRepository;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<String>> AuthinticateUser(CustomerAuthDto customerinfo)
        {
            var customer = await _customerRepository.GetCustomer(customerinfo.FirstName, customerinfo.LastName);
            if (customer is null)
            {
                return BadRequest("First name or last name is worng");
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tkey = Encoding.UTF8.GetBytes(configuration["JWTToken:Key"]);
            var TokenDescp = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                    new Claim("FirstName", customer.First_Name),
                    new Claim("LastName", customer.Last_Name),
                    new Claim("Id", customer.CustomerId.ToString()),
                    new Claim("Email",customer.Email),
                    new Claim("Type","Customer")
                }),
                Issuer = configuration["JWTToken:Issuer"],
                Audience = configuration["JWTToken:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(TokenDescp);
            return tokenhandler.WriteToken(token);
        }

        [HttpPost("employee")]
        public async Task<ActionResult<String>> AuthinticateEmployee(EmployeeAuthDto employeeInfo)
        {
            var employee = await employeeRepository.GetEmployee(employeeInfo.FirstName, employeeInfo.LastName, employeeInfo.RestaurantId);
            if (employee is null)
            {
                return BadRequest("First name, last name or restaurantId is worng");
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tkey = Encoding.UTF8.GetBytes(configuration["JWTToken:Key"]);
            var TokenDescp = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                    new Claim("FirstName", employee.First_Name),
                    new Claim("LastName", employee.Last_Name),
                    new Claim("Id", employee.EmployeeId.ToString()),
                    new Claim("RestaurentId",employee.RestaurantId.ToString()),
                    new Claim("Position",employee.Position.ToString()),
                    new Claim("Type","Employee")
                }),
                Issuer = configuration["JWTToken:Issuer"],
                Audience = configuration["JWTToken:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(TokenDescp);
            return tokenhandler.WriteToken(token);
        }

    }
}
