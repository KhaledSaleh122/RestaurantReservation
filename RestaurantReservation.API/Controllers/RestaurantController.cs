using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Restaurant;
using RestaurantReservation.Db;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : Controller
    {
        private readonly RestaurantRepository _repository;
        private readonly IMapper _mapper;

        public RestaurantController(RestaurantRepository repository)
        {
            _repository = repository;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDto>();
                cfg.CreateMap<RestaurantCreateDto, Restaurant>();
            });
            _mapper = configuration.CreateMapper();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetRestaurants()
        {
            var restaurants = await _repository.GetAllRestaurants();
            return Ok(_mapper.Map<IEnumerable<RestaurantDto>>(restaurants));
        }


        [HttpGet("{restaurantId}")]
        public async Task<ActionResult<RestaurantDto>> GetRestaurant(int restaurantId)
        {
            var restaurant = await _repository.GetRestaurant(restaurantId);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RestaurantDto>(restaurant));
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantDto>> CreateRestaurant([FromBody] RestaurantCreateDto restaurant)
        {

            var restaurantInfo = await _repository.CreateRestaurantAsync(_mapper.Map<Restaurant>(restaurant));
            return Ok(_mapper.Map<RestaurantDto>(restaurantInfo));
        }

        [HttpPut("{restaurantId}")]
        public async Task<ActionResult> UpdateRestaurant(int restaurantId, [FromBody] RestaurantCreateDto restaurantinfo)
        {

            var restaurant = await _repository.GetRestaurant(restaurantId);
            if (restaurant is null)
            {
                return NotFound();
            }
            _mapper.Map(restaurantinfo, restaurant);
            await _repository.UpdateRestaurantAsync(restaurant);
            return Ok();
        }

        [HttpDelete("{restaurantId}")]
        public async Task<ActionResult> DeleteRestaurant(int restaurantId)
        {
            var restaurant = await _repository.GetRestaurant(restaurantId);
            if (restaurant is null)
            {
                return NotFound();
            }
            await _repository.DeleteRestaurantAsync(restaurantId);
            return Ok();
        }

    }
}