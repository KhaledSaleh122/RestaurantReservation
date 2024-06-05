using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantReservation;
using RestaurantReservation.API.Models.Order;
using RestaurantReservation.API.Models.Reservation;
using RestaurantReservation.Db;

namespace ReservationReservation.API.Controllers
{
    [ApiController]
    [Route("api/restaurants/{restaurantId}/tables/{tableId}/reservations")]
    public class ReservationController : Controller
    {
        private readonly ReservationRepository _repository;
        private readonly RestaurantRepository restaurantRepository;
        private readonly TableRepository tableRepository;
        private readonly CustomerRepository customerRepository;
        private readonly IMapper _mapper;

        public ReservationController(ReservationRepository repository, RestaurantRepository restaurantRepository,
            TableRepository tableRepository, CustomerRepository customerRepository)
        {
            _repository = repository;
            this.restaurantRepository = restaurantRepository;
            this.tableRepository = tableRepository;
            this.customerRepository = customerRepository;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reservation, ReservationDto>();
                cfg.CreateMap<ReservationCreateDto, Reservation>();
                cfg.CreateMap<OrderItem, OrderItemsDto>();
            });
            _mapper = configuration.CreateMapper();
        }

        [HttpGet("{reservationId}/menu-items")]
        public async Task<ActionResult<IEnumerable<OrderItemsDto>>> GetMenuItems(int restaurantId, int tableId, int reservationId)
        {
            var resturent = await restaurantRepository.GetRestaurant(restaurantId);
            if (resturent is null)
            {
                return NotFound();
            }
            var reservation = await _repository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }

            var menuItems = await _repository.GetReservationMenuItems(reservationId);
            return Ok(_mapper.Map<IEnumerable<OrderItemsDto>>(menuItems));
        }


        [HttpGet("/api/restaurants/reservations/customer/{customerId}")]
        [Authorize(Policy = "Employee")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations(int customerId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var customer = await customerRepository.GetCustomer(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var reservations = await _repository.GetAllReservationsCustomer(restaurantId, customerId);
            return Ok(_mapper.Map<IEnumerable<ReservationDto>>(reservations));
        }

        [HttpGet]
        [Authorize(Policy = "Customer")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations(int restaurantId, int tableId)
        {
            var reservations = await _repository.GetAllReservations(restaurantId, tableId);
            return Ok(_mapper.Map<IEnumerable<ReservationDto>>(reservations));
        }

        [HttpGet("{reservationId}")]
        [Authorize(Policy = "Customer")]
        public async Task<ActionResult<ReservationDto>> GetReservation(int restaurantId, int tableId, int reservationId)
        {
            var resturent = await restaurantRepository.GetRestaurant(restaurantId);
            if (resturent is null)
            {
                return NotFound();
            }
            var reservation = await _repository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReservationDto>(reservation));
        }

        [HttpPost]
        [Authorize(Policy = "Customer")]
        public async Task<ActionResult<ReservationDto>> CreateReservation(int restaurantId, int tableId, [FromBody] ReservationCreateDto reservation)
        {
            var resturent = await restaurantRepository.GetRestaurant(restaurantId);
            if (resturent is null)
            {
                return NotFound();
            }

            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }
            var reservationFinal = _mapper.Map<Reservation>(reservation);
            reservationFinal.RestaurantId = restaurantId;
            reservationFinal.TableId = tableId;
            reservationFinal.CustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id")!.Value);
            var reservationInfo = await _repository.CreateReservationAsync(reservationFinal);
            return Ok(_mapper.Map<ReservationDto>(reservationInfo));
        }

        [HttpPut("{reservationId}")]
        [Authorize(Policy = "Customer")]
        public async Task<ActionResult> UpdateReservation(int restaurantId, int tableId, int reservationId, [FromBody] ReservationCreateDto reservationinfo)
        {
            var resturent = await restaurantRepository.GetRestaurant(restaurantId);
            if (resturent is null)
            {
                return NotFound();
            }

            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }
            var reservation = await _repository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            _mapper.Map(reservationinfo, reservation);
            await _repository.UpdateReservationAsync(reservation);
            return Ok();
        }

        [HttpDelete("{reservationId}")]
        [Authorize(Policy = "Customer")]
        public async Task<ActionResult> DeleteReservation(int restaurantId, int tableId, int reservationId)
        {
            var resturent = await restaurantRepository.GetRestaurant(restaurantId);
            if (resturent is null)
            {
                return NotFound();
            }

            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }
            var reservation = await _repository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            await _repository.DeleteReservationAsync(reservationId);
            return Ok();
        }

    }
}