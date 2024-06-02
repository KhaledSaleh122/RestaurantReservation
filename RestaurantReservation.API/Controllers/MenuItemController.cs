using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.MenuItem;
using RestaurantReservation.Db;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/restaurents/menuItems")]
    [Authorize(Policy = "Manager")]
    public class MenuItemController : Controller
    {
        private readonly MenuItemRepository _repository;
        private readonly RestaurantRepository restaurantRepository;
        private readonly IMapper _mapper;

        public MenuItemController(MenuItemRepository repository, RestaurantRepository restaurantRepository)
        {
            _repository = repository;
            this.restaurantRepository = restaurantRepository;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MenuItem, MenuItemDto>();
                cfg.CreateMap<MenuItemCreateDto, MenuItem>();
            });
            _mapper = configuration.CreateMapper();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems()
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var menuItems = await _repository.GetAllMenuItems(restaurantId);
            return Ok(_mapper.Map<IEnumerable<MenuItemDto>>(menuItems));
        }

        [HttpGet("{menuItemId}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItem(int menuItemId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var menuItem = await _repository.GetItem(restaurantId, menuItemId);
            if (menuItem is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MenuItemDto>(menuItem));
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemDto>> CreateMenuItem([FromBody] MenuItemCreateDto menuItem)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var finialMenuItem = _mapper.Map<MenuItem>(menuItem);
            finialMenuItem.RestaurantId = restaurantId;
            var menuItemInfo = await _repository.CreateMenuItemAsync(finialMenuItem);
            return Ok(_mapper.Map<MenuItemDto>(menuItemInfo));
        }

        [HttpPut("{menuItemId}")]
        public async Task<ActionResult> UpdateMenuItem(int menuItemId, [FromBody] MenuItemCreateDto menuIteminfo)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var menuItem = await _repository.GetItem(restaurantId, menuItemId);
            if (menuItem is null)
            {
                return NotFound();
            }
            _mapper.Map(menuIteminfo, menuItem);
            await _repository.UpdateMenuItemAsync(menuItem);
            return Ok();
        }

        [HttpDelete("{menuItemId}")]
        public async Task<ActionResult> DeleteMenuItem(int menuItemId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var menuItem = await _repository.GetItem(restaurantId, menuItemId);
            if (menuItem is null)
            {
                return NotFound();
            }
            await _repository.DeleteMenuItemAsync(menuItemId);
            return Ok();
        }

    }
}

